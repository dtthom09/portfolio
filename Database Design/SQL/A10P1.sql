create table EMPLOYEEDIM
(
	EMP_CODE int identity not null,
	EMP_NUM int not null,
	EMP_TITLE char(4),
	EMP_LNAME char(15),
	EMP_FNAME char(15),
	EMP_INITIAL char(1),
	EMP_DOB datetime,
	EMP_HIRE_DATE datetime
);

create table AIRPLANEDIM
(
	AC_CODE int identity not null,
	AC_NUMBER char(5) not null,
	MOD_CODE char(10),
	MOD_NAME char(20)
);

create table TIMEDIM
(
	TIME_ID int identity not null,
	CHAR_DATE datetime,
	MONTH AS MONTH(CHAR_DATE),
	YEAR AS YEAR(CHAR_DATE)
);

create table FACT
(
	EMP_CODE int not null,
	AC_CODE int not null,
	TIME_ID int not null,
	CHAR_FUEL_GALLONS float,
	CHAR_HOURS_FLOWN float,
	MOD_CHG_MILE real,
	REVENUE AS CHAR_FUEL_GALLONS * MOD_CHG_MILE
);


alter table FACT drop constraint FK_FACT_EMP_CODE, 
								 FK_FACT_AC_CODE,
								 FK_FACT_TIME_ID;
alter table airplanedim drop constraint PK_AC_CODE;
alter table EMPLOYEEDIM drop constraint PK_EMP_CODE;
alter table TIMEDIM drop constraint PK_TIME_ID;

truncate table airplanedim;
truncate table employeedim;
truncate table timedim;

alter table FACT drop constraint FK_FACT_EMP_CODE, 
								 FK_FACT_AC_CODE,
								 FK_FACT_TIME_ID;
alter table airplanedim drop constraint PK_AC_CODE;
alter table EMPLOYEEDIM drop constraint PK_EMP_CODE;
alter table TIMEDIM drop constraint PK_TIME_ID;