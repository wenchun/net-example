// From_C.h : main header file for the FROM_C application
//

#if !defined(AFX_FROM_C_H__1F175291_E9AC_47EC_BFE0_56BE721AB765__INCLUDED_)
#define AFX_FROM_C_H__1F175291_E9AC_47EC_BFE0_56BE721AB765__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CFrom_CApp:
// See From_C.cpp for the implementation of this class
//

class CFrom_CApp : public CWinApp
{
public:
	CFrom_CApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFrom_CApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CFrom_CApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FROM_C_H__1F175291_E9AC_47EC_BFE0_56BE721AB765__INCLUDED_)
