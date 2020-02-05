//#include <tchar.h> 
//
//#include "windows.h" 
//
//#include <tlhelp32.h> 
//
//#include "string.h" 
//
//#include <iostream> 
//
//#define STRLEN(x) (sizeof(x)/sizeof(TCHAR) - 1) 
//bool AreEqual(const TCHAR *a, const TCHAR *b)
//
//{
//
//	while (*a == *b)
//
//	{
//
//		if (*a == _TEXT('\0'))return true;
//
//		a++; b++;
//
//	}
//
//	return false;
//
//}
//
//bool IsProcessRun()
//
//{
//
//	bool RUN;
//
//	TCHAR buf[] = TEXT("Steam.exe");
//
//	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
//
//	PROCESSENTRY32 pe;
//
//	pe.dwSize = sizeof(PROCESSENTRY32);
//
//	Process32First(hSnapshot, &pe);
//
//	if (AreEqual(pe.szExeFile, buf))
//
//	{
//
//		RUN = true;
//
//		return RUN;
//
//	}
//
//	else
//
//		RUN = false;
//
//	while (Process32Next(hSnapshot, &pe))
//
//	{
//
//		if (AreEqual(pe.szExeFile, buf))
//
//		{
//
//			RUN = true;
//
//			return RUN;
//
//		}
//
//		else
//
//			RUN = false;
//
//	}
//
//	return RUN;
//
//}
//
//int _tmain(int argc, _TCHAR* argv[])
//
//{
//
//	WIN32_FIND_DATA FindFileData;
//
//	HANDLE hFind = INVALID_HANDLE_VALUE;
//
//	TCHAR directorySearch[] = TEXT("D:\Steam*");
//
//	TCHAR filesearch[] = TEXT("D:\\Steam\\Steam*.exe");
//
//	// Find the first file in the directory. 
//
//	hFind = FindFirstFile(filesearch, &FindFileData);
//
//	if (hFind == INVALID_HANDLE_VALUE)
//
//	{
//
//		printf("Invalid file handle. Error is %u.\n", GetLastError());
//
//	}
//
//	else
//
//	{
//
//		std::wcout << "Found: " << FindFileData.cFileName << '\n';
//
//		// List all the other files in the directory. 
//
//		while (FindNextFile(hFind, &FindFileData) != 0)
//
//		{
//
//			std::wcout << "Found: " << FindFileData.cFileName << '\n';
//
//		}
//
//		FindClose(hFind);
//
//	}
//
//	getchar();
//
//	STARTUPINFO cif;
//
//	ZeroMemory(&cif, sizeof(STARTUPINFO));
//
//	PROCESS_INFORMATION pi;
//
//	TCHAR buf[] = TEXT("D:\\Steam\\Steam.exe");
//
//	if (!(CreateProcess(NULL, buf, NULL, NULL, FALSE, 0, NULL, NULL, &cif, &pi)))
//
//		std::wcout << "Error " << '\n';
//
//	getchar();
//
//	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
//
//	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY | BACKGROUND_BLUE);
//
//	if (IsProcessRun())
//
//	{
//
//		std::wcout << "Running" << '\n';
//
//	}
//
//	else
//
//	{
//
//		std::wcout << "NOT Running" << '\n';
//
//	}
//
//	getchar();
//
//
//	return 0;
//
//}

#include <tchar.h> 
#include <windows.h>
#include <iostream>
#include "string.h"



DWORD WINAPI myThread(void* lpParameter)
{
	int a = 20, b;
	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 20)
	{
		Sleep(1000);
		counter++;
		b = a + counter;
		printf("\n b = %d", b);
	}

	return 0;
}

DWORD WINAPI myThread1(void* lwParameter)
{
	int a = 145, d;
	int* counterp = new int();
	counterp = (int*)lwParameter;
	int counter = *counterp;

	while (counter < 20)
	{
		Sleep(1000);
		counter++;
		d = a/counter;
		printf("\n d = %d", d);

	}
	printf("\n counter = %d", counter);
	return 0;
}

int _tmain(int argc, _TCHAR* argv[])
{

	int z = 5;

	unsigned int myCounter = 0;
	DWORD myThreadID;
	DWORD myThreadID1;
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& z, 0, &myThreadID);
	HANDLE myHandle1 = CreateThread(0, 0, myThread1, (void*)& z, 0, &myThreadID1);
	myCounter++;
	Sleep(10000);
	TerminateThread(myHandle, 0);
	TerminateThread(myHandle1, 0);
	getchar();

	return 0;
}

