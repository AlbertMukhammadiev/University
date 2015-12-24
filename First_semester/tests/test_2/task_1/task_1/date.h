#pragma once

struct Date;

Date *createDate();

void fillingDate(Date *date, int numberOfField, int buffer);

void copyDate(Date *to, Date *from);

void comparingDates(Date *maxDate, Date *newDate);

void printDate(Date *date);