// TO_CDlg.h : header file
//

#if !defined(AFX_TO_CDLG_H__32C617EB_1A1B_44FB_B227_8A37A785BFAB__INCLUDED_)
#define AFX_TO_CDLG_H__32C617EB_1A1B_44FB_B227_8A37A785BFAB__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CTO_CDlg dialog

class CTO_CDlg : public CDialog
{
// Construction
public:
	CTO_CDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CTO_CDlg)
	enum { IDD = IDD_TO_C_DIALOG };
	CEdit	m_Tag;
	CEdit	m_Edit;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTO_CDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual LRESULT WindowProc(UINT message, WPARAM wParam, LPARAM lParam);
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CTO_CDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	virtual void OnOK();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TO_CDLG_H__32C617EB_1A1B_44FB_B227_8A37A785BFAB__INCLUDED_)
