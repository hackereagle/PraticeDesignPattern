#ifndef _RORZE_LOGGER_H_
#define _RORZE_LOGGER_H_ 


class SigletonPattern
{
public:
    static SigletonPattern GetInsance();
    ~SigletonPattern();
    void AsyncWrite(char *msg);

private:
    SigletonPattern();
    static SigletonPattern *mInstance;

};
 #endif //_RORZE_LOGGER_H_