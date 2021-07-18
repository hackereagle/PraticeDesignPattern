#include <string>
#include <iostream>
#include <mutex>
#include "SigletonPattern.h"

SigletonPattern *SigletonPattern::mInstance;
std::mutex obj;

SigletonPattern::SigletonPattern()
{

}

SigletonPattern::~SigletonPattern()
{

}

SigletonPattern SigletonPattern::GetInsance()
{
    std::lock_guard<std::mutex> lock(obj);
    if(SigletonPattern::mInstance == nullptr){
        SigletonPattern::mInstance = new SigletonPattern();
    }

    return *SigletonPattern::mInstance;
}

void SigletonPattern::AsyncWrite(char* msg)
{
    std::cout << std::string(msg) << std::endl;
}