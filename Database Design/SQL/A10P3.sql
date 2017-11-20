--STEP 0
--DROP CONSTRAINT
alter table FACT 
drop constraint PK_FACT,
				FK_FACT_AC,
				FK_FACT_EMP,
				FK_FACT_TIME

alter table airplanedim 
drop constraint PK_AC

alter table EMPLOYEEDIM 
drop constraint PK_EMP

alter table TIMEDIM 
drop constraint PK_TIME

--TRUNCATE TABLE
truncate table airplanedim;
truncate table employeedim;
truncate table timedim;
truncate table fact;

--ADD CONSTRAINT
alter table airplanedim 
ADD constraint PK_AC PRIMARY KEY (AC_CODE)

alter table EMPLOYEEDIM 
ADD constraint PK_EMP PRIMARY KEY (EMP_CODE)

alter table TIMEDIM 
ADD constraint PK_TIME PRIMARY KEY (TIME_ID)

alter table FACT 
ADD constraint PK_FACT PRIMARY KEY (AC_CODE, EMP_CODE, TIME_ID),
	constraint FK_FACT_AC FOREIGN KEY (AC_CODE) REFERENCES airplanedim,
	CONSTRAINT FK_FACT_EMP FOREIGN KEY (EMP_CODE) REFERENCES EMPLOYEEDIM,
	CONSTRAINT FK_FACT_TIME FOREIGN KEY (TIME_ID) REFERENCES TIMEDIM

--STEP1
INSERT INTO EMPLOYEEDIM
SELECT EMP_NUM,
	   EMP_TITLE,
	   EMP_LNAME,
	   EMP_FNAME,
	   EMP_INITIAL,
	   EMP_DOB,
	   EMP_HIRE_DATE
FROM EMPLOYEE

INSERT INTO AIRPLANEDIM
SELECT AC.AC_NUMBER,
	   AC.MOD_CODE,
	   M.MOD_NAME
FROM AIRCRAFT AC 
	 INNER JOIN MODEL M ON AC.MOD_CODE = M.MOD_CODE

INSERT INTO TIMEDIM
SELECT CHAR_DATE
FROM CHARTER

--step 2
create table staging
(
	EMP_CODE int,
	AC_CODE int,
	TIME_ID int,
	EMP_NUM int,
	AC_NUMBER char(5),
	CHAR_DATE datetime,
);

alter table staging
add constraint PK_staging PRIMARY KEY (AC_CODE, EMP_CODE, TIME_ID),
	constraint FK_staging_AC FOREIGN KEY (AC_CODE) REFERENCES airplanedim,
	CONSTRAINT FK_staging_EMP FOREIGN KEY (EMP_CODE) REFERENCES EMPLOYEEDIM,
	CONSTRAINT FK_staging_TIME FOREIGN KEY (TIME_ID) REFERENCES TIMEDIM

alter table staging 
drop constraint PK_staging,
				FK_staging_AC,
				FK_staging_EMP,
				FK_staging_TIME

truncate table staging;

alter table staging
add constraint PK_staging PRIMARY KEY (AC_CODE, EMP_CODE, TIME_ID),
	constraint FK_staging_AC FOREIGN KEY (AC_CODE) REFERENCES airplanedim,
	CONSTRAINT FK_staging_EMP FOREIGN KEY (EMP_CODE) REFERENCES EMPLOYEEDIM,
	CONSTRAINT FK_staging_TIME FOREIGN KEY (TIME_ID) REFERENCES TIMEDIM

insert into staging(EMP_NUM, AC_NUMBER, CHAR_DATE)
select EMP_NUM,
	   AC_NUMBER,
	   CHAR_DATE
FROM CHARTER C
	 inner join pilot p on c.CHAR_PILOT = p.EMP_NUM

update staging
set EMP_CODE = e.EMP_CODE
from staging s
	 inner join EMPLOYEEDIM e on s.EMP_NUM = e.EMP_NUM

update staging
set AC_CODE = a.AC_CODE
from staging s 
	 inner join AIRPLANEDIM a on s.AC_NUMBER = a.AC_NUMBER

update staging 
set TIME_ID = TIME_ID
from staging s 
	 inner join TIMEDIM t on s.CHAR_DATE = t.CHAR_DATE

INSERT INTO FACT
SELECT EMP_CODE,
	   AC_CODE,
	   TIME_ID,
	   CHAR_FUEL_GALLONS,
	   CHAR_HOURS_FLOWN,
	   MOD_CHG_MILE,
	   CHAR_FUEL_GALLONS * MOD_CHG_MILE AS REVENUE
from staging s
	 inner join charter c on s.AC_NUMBER = c.AC_NUMBER
	 INNER JOIN AIRCRAFT AC ON C.AC_NUMBER = AC.AC_NUMBER
	 INNER JOIN MODEL M ON AC.MOD_CODE = M.MOD_CODE
