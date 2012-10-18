// Loader.cpp : 定义控制台应用程序的入口点。
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
    //判断注册表是否存在 
    for (int i=0;i<4;i++) 
    { 
        HKEY ck;//注册表的键 
 
		//检查注册表是否存在这个键值
        if(ERROR_SUCCESS == RegOpenKeyEx(HKEY_LOCAL_MACHINE,
			regeditVision[i],0,KEY_ALL_ACCESS,&ck))		  
        {        
            RegCloseKey(ck);//关闭注册表  
            res=TRUE; 
            break; 
        } 
        else   
        {   
			cout<<"系统里没安装.net3.5，现在开始安装!"<<endl;
            res=FALSE; 
        } 
    } 
    return res; 
} 

int InstallNET4(){
	  
		STARTUPINFO stinfo;//当创建新进程时，将使用该结构的有关成员
        ZeroMemory((void*)&stinfo,   sizeof(STARTUPINFO));//把stinfo置空
        PROCESS_INFORMATION   ProcessInfo;//进程信息的数据结构
        stinfo.cb   =   sizeof(STARTUPINFO);//包含STARTUPINFO结构中的字节数
        stinfo.dwFlags   =   STARTF_USESHOWWINDOW;//显示窗口
        stinfo.wShowWindow   =   SW_SHOW;//该应用程序的第一个重叠窗口应该如何出现
		cout<<"正在安装.net framework 4...."<<endl;
        if(!CreateProcess(".\\dotNetFx40_Full_x86_x64.exe","/q /norestart /ChainingPackage FullX64Bootstrapper",NULL,NULL,false,0,NULL,NULL,&stinfo,&ProcessInfo))
        {
              //DWORD dwRet = GetLastError();//启动失败，获取异常值
            return 0;
        }
        else
        {
            WaitForSingleObject(ProcessInfo.hProcess, INFINITE);//等待安装完成，此方法为阻塞方法！
            return 1;
        }
}


int StartExe(LPSTR path)
{
        STARTUPINFO stinfo;//当创建新进程时，将使用该结构的有关成员
        ZeroMemory((void*)&stinfo,   sizeof(STARTUPINFO));//把stinfo置空
        PROCESS_INFORMATION   ProcessInfo;//进程信息的数据结构
        stinfo.cb   =   sizeof(STARTUPINFO);//包含STARTUPINFO结构中的字节数
        stinfo.dwFlags   =   STARTF_USESHOWWINDOW;//显示窗口
        stinfo.wShowWindow   =   SW_SHOW;//该应用程序的第一个重叠窗口应该如何出现
        if(!CreateProcess(path,path,NULL,NULL,false,0,NULL,NULL,&stinfo,&ProcessInfo))
        {
              //DWORD dwRet = GetLastError();//启动失败，获取异常值
            return 0;
        }
        else
        {
            WaitForSingleObject(ProcessInfo.hProcess, INFINITE);//等待安装完成，此方法为阻塞方法！
            return 1;
        }
}

int StartCheck()
{
	cout<<"正在启动..."<<endl;
    LPSTR sNetfile   =   ".\\net4.exe";   //你的.net安装包的路径
    LPSTR sExefile   =   ".\\Jade.Form.exe";   //你的程序的路径
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

