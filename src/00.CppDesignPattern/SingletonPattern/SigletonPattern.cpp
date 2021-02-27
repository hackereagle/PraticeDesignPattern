#include "SigletonPattern.h"
#include <string>
#include <iostream>

SigletonPattern::SigletonPattern()
{

}

SigletonPattern::~SigletonPattern()
{

}

SigletonPattern *SigletonPattern::GetInsance()
{
    if(SigletonPattern::mInstance == nullptr){
        SigletonPattern::mInstance = new SigletonPattern();
    }

    return SigletonPattern::mInstance;
}

void SigletonPattern::AsyncWrite(char* msg)
{
    std::cout << std::string(msg) << std::endl;
}