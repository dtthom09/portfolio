create table EMPLOYEEDIM
(
	EMP_CODE int identity not null,
	EMP_NUM int,
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
	AC_NUMBER char(5),
	MOD_CODE char(10),
	MOD_NAME char(20)
);

create table TIMEDIM
(
	TIME_ID int identity not null,
	CHAR_DATE datetime
);

create table FACT
(
	EMP_CODE int not null,
	AC_CODE int not null,
	TIME_ID int not null,
	CHAR_FUEL_GALLONS float,
	CHAR_DISTANCE real,
	MOD_CHG_MILE real,
	REVENUE AS CHAR_FUEL_GALLONS * MOD_CHG_MILE
);

alter table airplanedim 
add constraint PK_AC PRIMARY KEY (AC_CODE)

alter table EMPLOYEEDIM 
ADD constraint PK_EMP PRIMARY KEY (EMP_CODE)

alter table TIMEDIM 
ADD constraint PK_TIME PRIMARY KEY (TIME_ID)

alter table FACT
add constraint PK_FACT PRIMARY KEY (AC_CODE, EMP_CODE, TIME_ID),
	constraint FK_FACT_AC FOREIGN KEY (AC_CODE) REFERENCES airplanedim,
	CONSTRAINT FK_FACT_EMP FOREIGN KEY (EMP_CODE) REFERENCES EMPLOYEEDIM,
	CONSTRAINT FK_FACT_TIME FOREIGN KEY (TIME_ID) REFERENCES TIMEDIM