// TO_CDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TO_C.h"
#include "TO_CDlg.h"
#include "..\\WmCpyDta\\wmcpydta.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTO_CDlg dialog

CTO_CDlg::CTO_CDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTO_CDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTO_CDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTO_CDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTO_CDlg)
	DDX_Control(pDX, IDC_TAG, m_Tag);
	DDX_Control(pDX, IDC_EDIT1, m_Edit);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CTO_CDlg, CDialog)
	//{{AFX_MSG_MAP(CTO_CDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTO_CDlg message handlers

BOOL CTO_CDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTO_CDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CTO_CDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CTO_CDlg::OnOK() 
{
	// TODO: Add extra validation here
	
	CDialog::OnOK();
}

LRESULT CTO_CDlg::WindowProc(UINT message, WPARAM wParam, LPARAM lParam) 
{
	// TODO: Add your specialized code here and/or call the base class
	BOOL bUsed(FALSE);

	if(message == WM_COPYDATA)
	{

		BOOL bOurMessage(FALSE); //assume the message was not intended for this application

	//Option 1 - Encryption
	//To make a message a little more difficult to hack we can make it look like a bad piece of memory.
	//The sender must also set the same value.
	WmCpyDta_SetEncrypt('d'); // 'd' is a bitwise seed value. I like to use d because it
								//makes the message look like bad memory

	/*Option 2
	//If your receiver wants to conditional handle the received message
	//then define new ids based on the default.
	//This example does not need this so we will define a few but not use them.
	//Look for more comments on wCustomMsgId_1, and wCustomMsgId_2 below.
	WPARAM wCustomMsgId_1 = WmCpyDta_BaseDefaultMsgId() + 1;
	WPARAM wCustomMsgId_2 = WmCpyDta_BaseDefaultMsgId() + 2;
		If some condition then
		WmCpyDta_SetMessageId(wCustomMsgId_1);
		else some other conditin WmCpyDta_SetMessageId(wCustomMsgId_2);
	*/

	WmCpyDta_SetMessageId(WmCpyDta_BaseDefaultMsgId());//define for default behavior

	
	/* Option 3
	The default behavior of the dll is only to accept messages send by the dll.
	If you want to be more specific then set WmCpyDta_SetSenderId(HWND hSenderId);
	The receiver can then use this value to decide if the message should be accepted.

	The 2nd parameter == NULL in WmCpyDta_SendMessage_sTagData() is the same as
	explicity using WmCpyDta_GetSenderId().

	I do not want to couple my programs that tightly, so I will stick with the default behavior.
	*/

		CString strTag, strData;
		strTag.GetBufferSetLength(WmCpyDta_MaxTagLen());//allocate space for incoming text
		strData.GetBufferSetLength(WmCpyDta_MaxDataLen());//allocate space for incoming text
		bOurMessage = WmCpyDta_GetMessage_sTagData(NULL, NULL, lParam, strTag.GetBuffer(0), strData.GetBuffer(0));
		if(bOurMessage)
		{
			/*
			if we need to decide how to use the message
			if(WmCpyDta_GetMessageId() == wCustomMsgId_1)
			then do process 1
			else if(WmCpyDta_GetMessageId() == wCustomMsgId_2)
			then do process 2

			However, in this demo we are just putting the values it text boxes,
			we do not have conditions.
			*/

			m_Tag.SetWindowText(strTag);
			m_Edit.SetWindowText(strData);

		}
				
		if(bOurMessage)
			return 0; //we used the message, no need to pass along to the dialog

	
	}

	return CDialog::WindowProc(message, wParam, lParam);
	
}


