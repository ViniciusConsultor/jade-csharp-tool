// Loader.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <stdio.h>
#include <windows.h>
#include <iostream>

using namespace std;

LPSTR regeditVision[] ={"SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v3.5", 
"SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4.0"}; 
 
bool CheckReg() 
{    
    bool res=TRUE; 
    //�ж�ע����Ƿ���� 
    for (int i=0;i<4;i++) 
    { 
        HKEY ck;//ע���ļ� 
 
		//���ע����Ƿ���������ֵ
        if(ERROR_SUCCESS == RegOpenKeyEx(HKEY_LOCAL_MACHINE,
			regeditVision[i],0,KEY_ALL_ACCESS,&ck))		  
        {        
            RegCloseKey(ck);//�ر�ע���  
            res=TRUE; 
            break; 
        } 
        else   
        {   
			cout<<"ϵͳ��û��װ.net3.5�����ڿ�ʼ��װ!"<<endl;
            res=FALSE; 
        } 
    } 
    return res; 
} 

int InstallNET4(){
	  
		STARTUPINFO stinfo;//�������½���ʱ����ʹ�øýṹ���йس�Ա
        ZeroMemory((void*)&stinfo,   sizeof(STARTUPINFO));//��stinfo�ÿ�
        PROCESS_INFORMATION   ProcessInfo;//������Ϣ�����ݽṹ
        stinfo.cb   =   sizeof(STARTUPINFO);//����STARTUPINFO�ṹ�е��ֽ���
        stinfo.dwFlags   =   STARTF_USESHOWWINDOW;//��ʾ����
        stinfo.wShowWindow   =   SW_SHOW;//��Ӧ�ó���ĵ�һ���ص�����Ӧ����γ���
		cout<<"���ڰ�װ.net framework 4...."<<endl;
        if(!CreateProcess(".\\dotNetFx40_Full_x86_x64.exe","/q /norestart /ChainingPackage FullX64Bootstrapper",NULL,NULL,false,0,NULL,NULL,&stinfo,&ProcessInfo))
        {
              //DWORD dwRet = GetLastError();//����ʧ�ܣ���ȡ�쳣ֵ
            return 0;
        }
        else
        {
            WaitForSingleObject(ProcessInfo.hProcess, INFINITE);//�ȴ���װ��ɣ��˷���Ϊ����������
            return 1;
        }
}


int StartExe(LPSTR path)
{
        STARTUPINFO stinfo;//�������½���ʱ����ʹ�øýṹ���йس�Ա
        ZeroMemory((void*)&stinfo,   sizeof(STARTUPINFO));//��stinfo�ÿ�
        PROCESS_INFORMATION   ProcessInfo;//������Ϣ�����ݽṹ
        stinfo.cb   =   sizeof(STARTUPINFO);//����STARTUPINFO�ṹ�е��ֽ���
        stinfo.dwFlags   =   STARTF_USESHOWWINDOW;//��ʾ����
        stinfo.wShowWindow   =   SW_SHOW;//��Ӧ�ó���ĵ�һ���ص�����Ӧ����γ���
        if(!CreateProcess(path,path,NULL,NULL,false,0,NULL,NULL,&stinfo,&ProcessInfo))
        {
              //DWORD dwRet = GetLastError();//����ʧ�ܣ���ȡ�쳣ֵ
            return 0;
        }
        else
        {
            WaitForSingleObject(ProcessInfo.hProcess, INFINITE);//�ȴ���װ��ɣ��˷���Ϊ����������
            return 1;
        }
}

int StartCheck()
{
	cout<<"��������..."<<endl;
    LPSTR sNetfile   =   ".\\net4.exe";   //���.net��װ����·��
    LPSTR sExefile   =   ".\\Jade.Form.exe";   //��ĳ����·��
    if(CheckReg())
    {        
        WinExec(sExefile, SW_SHOW);
    }
    else
    {
        InstallNET4();
        StartCheck();
    }
    return 1;
}

int main(void)
{    
    StartCheck();
    return 0;
}

