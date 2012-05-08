// From_CDlg.cpp : implementation file
//

#include "stdafx.h"
#include "From_C.h"
#include "From_CDlg.h"
#include <afxdisp.h>
#include "..\\WmCpyDta\\wmcpydta.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CFrom_CDlg dialog

CFrom_CDlg::CFrom_CDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CFrom_CDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CFrom_CDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CFrom_CDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CFrom_CDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CFrom_CDlg, CDialog)
	//{{AFX_MSG_MAP(CFrom_CDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_PING, OnPing)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFrom_CDlg message handlers

BOOL CFrom_CDlg::OnInitDialog()
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

void CFrom_CDlg::OnPaint() 
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
HCURSOR CFrom_CDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CFrom_CDlg::OnCancel() 
{
	// TODO: Add extra cleanup here
	
	CDialog::OnCancel();
}


void CFrom_CDlg::OnPing() 
{
	//1st, lets send a message to the C++ receiving program.
	//WmCpyDta_StringTest();

	const CString cstrReceiverWindowName("I AM THE C++ RECEIVER WINDOW");
	//1st find who to send the data to
	HWND hReciever = ::FindWindow(NULL, cstrReceiverWindowName);;
	HWND hSender = NULL;
	CString strData, strTag("Tag1");
	
	COleDateTime dt(COleDateTime::GetCurrentTime());
	strData.Format("Send this date time string %04d/%02d/%02d %02d:%02d:%02d",dt.GetYear(), dt.GetMonth(), dt.GetDay(),
		dt.GetHour(), dt.GetMinute(), dt.GetSecond());


	//Option 1 - Encryption
	//To make a message a little more difficult to hack we can make it look like a bad piece of memory.
	//The receiver must also set the same value.
	WmCpyDta_SetEncrypt('d'); // 'd' is a bitwise seed value. I like to use d because it 
								//makes the message look like bad memory

	/*Option 2
	//If your receiver wants to conditional handle the received message
	//then define new ids based on the default.
	//This example does not need this so we will define a few but not use them.
	WPARAM wCustomMsgId_1 = WmCpyDta_BaseDefaultMsgId() + 1;
	WPARAM wCustomMsgId_2 = WmCpyDta_BaseDefaultMsgId() + 2;
		If some condition then
		WmCpyDta_SetMessageId(wCustomMsgId_1);
		else some other conditin WmCpyDta_SetMessageId(wCustomMsgId_2);
	*/

	
	/* Option 3
	The default behavior of the dll is only to accept messages send by the dll.
	If you want to be more specific then set WmCpyDta_SetSenderId(HWND hSenderId);
	The receiver can then use this value to decide if the message should be accepted.

	The 2nd parameter == NULL in WmCpyDta_SendMessage_sTagData() is the same as
	explicity using WmCpyDta_GetSenderId().

	I do not want to couple my programs that tightly, so I will stick with the default behavior.
	*/

	if(hReciever) //send the data
		WmCpyDta_SendMessage_sTagData(hReciever, NULL, strTag.GetBuffer(0), strData.GetBuffer(0));

	//---------------------------------------------------------
   //Now send the same message to the C Sharpe program

	const CString cstrReceiverWindowNameCSharp("I AM THE C SHARP RECEIVER WINDOW");
	//1st find who to send the data to
	HWND hRecieverCSharp = ::FindWindow(NULL, cstrReceiverWindowNameCSharp);
	if(hRecieverCSharp) //send the data
		WmCpyDta_SendMessage_sTagData(hRecieverCSharp, NULL, strTag.GetBuffer(0), strData.GetBuffer(0));


	



}
