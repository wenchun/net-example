// From_CDlg.h : header file
//

#if !defined(AFX_FROM_CDLG_H__BE645D58_4D3B_4639_B512_BFCC89CF06E0__INCLUDED_)
#define AFX_FROM_CDLG_H__BE645D58_4D3B_4639_B512_BFCC89CF06E0__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CFrom_CDlg dialog

class CFrom_CDlg : public CDialog
{
// Construction
public:
	CFrom_CDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CFrom_CDlg)
	enum { IDD = IDD_FROM_C_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFrom_CDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CFrom_CDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	virtual void OnCancel();
	afx_msg void OnPing();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FROM_CDLG_H__BE645D58_4D3B_4639_B512_BFCC89CF06E0__INCLUDED_)
