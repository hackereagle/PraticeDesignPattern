#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "SigletonPattern.h"

int main(int argc, char** argv)
{
	SigletonPattern::GetInsance().AsyncWrite((char*)"Test");

	getchar();
	return EXIT_SUCCESS;
}