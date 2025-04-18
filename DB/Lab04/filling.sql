﻿use UNIVER;

create table AUDITORIUM_TYPE 
(    AUDITORIUM_TYPE  char(10) constraint AUDITORIUM_TYPE_PK  primary key,  
      AUDITORIUM_TYPENAME  varchar(30)       
 )
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )        values ('ЛК',            'Лекционная');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )         values ('ЛБ-К',          'Компьютерный класс');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME )         values ('ЛК-К',          'Лекционная с уст. проектором');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )          values  ('ЛБ-X',          'Химическая лаборатория');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME )        values  ('ЛБ-СК',   'Спец. компьютерный класс');
                      

  create table AUDITORIUM 
(   AUDITORIUM   char(20)  constraint AUDITORIUM_PK  primary key,              
    AUDITORIUM_TYPE     char(10) constraint  AUDITORIUM_AUDITORIUM_TYPE_FK foreign key         
                      references AUDITORIUM_TYPE(AUDITORIUM_TYPE), 
   AUDITORIUM_CAPACITY  integer constraint  AUDITORIUM_CAPACITY_CHECK default 1  check (AUDITORIUM_CAPACITY between 1 and 300),  -- вместимость 
   AUDITORIUM_NAME      varchar(50)                                     
)
insert into  AUDITORIUM   (AUDITORIUM, AUDITORIUM_NAME,  
 AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
values  ('206-1', '206-1','ЛБ-К', 15);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY) 
values  ('301-1',   '301-1', 'ЛБ-К', 15);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )   
values  ('236-1',   '236-1', 'ЛК',   60);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )  
values  ('313-1',   '313-1', 'ЛК-К',   60);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )  
values  ('324-1',   '324-1', 'ЛК-К',   50);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )   
 values  ('413-1',   '413-1', 'ЛБ-К', 15);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY ) 
values  ('423-1',   '423-1', 'ЛБ-К', 90);
insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, 
AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )     
values  ('408-2',   '408-2', 'ЛК',  90);


create table FACULTY
(    FACULTY      nvarchar(10)   primary key,
     FACULTY_NAME  nvarchar(50) default 'Не указано'
);
insert into FACULTY   (FACULTY,   FACULTY_NAME )
	values	('ХТиТ', 'Химическая технология и техника'),
			('ЛХФ', 'Лесохозяйственный факультет'),
			('ИЭФ', 'Инженерно-экономический факультет'),
			('ТТЛП', 'Технология и техника лесной промышленности'),
			('ТОВ', 'Технология органических веществ'),
			('ИТ', 'Факультет информационных технологий'),
			('ИДиП', 'Издательское дело и полиграфия');



create table PROFESSION
(     PROFESSION   nvarchar(20)  primary key,
      FACULTY    nvarchar(10) foreign key references FACULTY(FACULTY),
      PROFESSION_NAME nvarchar(100), 
	  QUALIFICATION   varchar(50)
);

insert into PROFESSION(FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)
	values	('ИТ',  '1-40 01 02',   'Информационные системы и технологии', 'инженерпрограммист-системотехник' ),
			('ХТиТ',  '1-36 01 08',    'Конструирование и производство из-делий из композиционных материалов', 'инженер-механик' ),
			('ХТиТ',  '1-36 07 01',  'Машины и аппараты химических производств и предприятий строительных материалов', 'инженер-механик' ),
			('ЛХФ',  '1-75 01 01',      'Лесное хозяйство', 'инженер лесного хозяйства' ),
			('ЛХФ',  '1-75 02 01',   'Садово-парковое строительство', 'инже-нер садово-паркового строительства' ),
			('ЛХФ',  '1-89 02 02',     'Туризм и природопользование', 'специ-алист в сфере туризма' ),
			('ИЭФ',  '1-25 01 07',  'Экономика и управление на предприятии', 'экономист-менеджер' ),
			('ИЭФ',  '1-25 01 08',    'Бухгалтерский учет, анализ и аудит', 'экономист' ),
			('ТТЛП',  '1-36 05 01',   'Машины и оборудование лесного ком-плекса', 'инженер-механик' ),
			('ТТЛП',  '1-46 01 01',      'Лесоинженерное дело', 'инженер-технолог' ),
			('ТОВ',  '1-48 01 02',  'Химическая технология органических веществ, материалов и изделий', 'инженер-химик-технолог' ),
			('ТОВ',  '1-48 01 05',    'Химическая технология переработки древесины', 'инженер-химик-технолог' ),
			('ТОВ',  '1-54 01 03',   'Физико-химические методы и приборы контроля качества продукции', 'инженер по сертификации' ),
			('ИДиП',  '1-47 01 01', 'Издательское дело', 'редактор-технолог' ),
			('ИДиП',  '1-36 06 01',  'Полиграфическое оборудование и си-стемы обработки информации', 'инженер-электромеханик' );


create table  PULPIT
(   PULPIT   nvarchar(20)   primary key,
    PULPIT_NAME  nvarchar(100),
    FACULTY   nvarchar(10)   foreign key references FACULTY(FACULTY)
);
insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY )
	values	('ИСиТ', 'Информационных систем и технологий ','ИТ'),
			('ЛВ', 'Лесоводства','ЛХФ'),
			('ЛУ', 'Лесоустройства','ЛХФ'),
			('ЛЗиДВ', 'Лесозащиты и древесиноведения','ЛХФ'),
			('ЛКиП', 'Лесных культур и почвоведения','ЛХФ'),
			('ТиП', 'Туризма и природопользования','ЛХФ'),
			('ЛПиСПС','Ландшафтного проектирования и садово-паркового строительства','ЛХФ'),
			('ТЛ', 'Транспорта леса', 'ТТЛП'),
			('ЛМиЛЗ','Лесных машин и технологии лесозаготовок','ТТЛП'),
			('ТДП','Технологий деревообрабатывающих производств', 'ТТЛП'),
			('ТиДИД','Технологии и дизайна изделий из древесины','ТТЛП'),
			('ОХ', 'Органической химии','ТОВ'),
			('ХПД','Химической переработки древесины','ТОВ'),
			('ТНВиОХТ','Технологии неорганических веществ и общей химической технологии ','ХТиТ'),
			('ПиАХП','Процессов и аппаратов химических производств','ХТиТ'),
			('ЭТиМ',    'Экономической теории и маркетинга','ИЭФ'),
			('МиЭП',   'Менеджмента и экономики природопользования','ИЭФ'),
			('СБУАиА', 'Статистики, бухгалтерского учета, анализа и аудита', 'ИЭФ'),
			('ПОиСОИ','Полиграфического оборудования и систем обработки инфор-мации ', 'ИДиП'),
			('БФ', 'Белорусской филологии','ИДиП'),
			('РИТ', 'Редакционно-издательских тенологий', 'ИДиП'),
			('ПП', 'Полиграфических производств','ИДиП');

			
create table TEACHER
(   TEACHER   nvarchar(10)    primary key,
    TEACHER_NAME  nvarchar(50),
    GENDER    nvarchar(1) CHECK (GENDER in ('м', 'ж')),
    PULPIT   nvarchar(20) foreign key references PULPIT(PULPIT)
);
insert into  TEACHER    (TEACHER,   TEACHER_NAME, GENDER, PULPIT )
	values	('СМЛВ', 'Смелов Владимир Владиславович', 'м', 'ИСиТ'),
			('АКНВЧ', 'Акунович Станислав Иванович', 'м', 'ИСиТ'),
			('КЛСНВ', 'Колесников Виталий Леонидович', 'м', 'ИСиТ'),
			('БРКВЧ', 'Бракович Андрей Игоревич', 'м', 'ИСиТ'),
			('ДТК', 'Дятко Александр Аркадьевич', 'м', 'ИСиТ'),
			('УРБ', 'Урбанович Павел Павлович', 'м', 'ИСиТ'),
			('ГРН', 'Гурин Николай Иванович', 'м', 'ИСиТ'),
			('ЖЛК', 'Жиляк Надежда Александровна',  'ж', 'ИСиТ'),
			('МРЗ', 'Мороз Елена Станиславовна',  'ж',   'ИСиТ'),
			('БРНВСК', 'Барановский Станислав Иванович', 'м', 'ЭТиМ'),
			('НВРВ', 'Неверов Александр Васильевич', 'м', 'МиЭП'),
			('ДМДК', 'Демидко Марина Николаевна',  'ж',  'ЛПиСПС'),
			('БРГ', 'Бурганская Татьяна Минаевна', 'ж', 'ЛПиСПС'),
			('РЖК', 'Рожков Леонид Николаевич ', 'м', 'ЛВ'),
			('ЗВГЦВ', 'Звягинцев Вячеслав Борисович', 'м', 'ЛЗиДВ'),
			('БЗБРДВ', 'Безбородов Владимир Степанович', 'м', 'ОХ'),
			('НСКВЦ', 'Насковец Михаил Трофимович', 'м', 'ТЛ'),
			('БРТШВЧ', 'Барташевич Святослав Александрович', 'м','ПОиСОИ'),
			('АРС', 'Арсентьев Виталий Арсентьевич', 'м', 'ПОиСОИ');



create table SUBJECT
(     [SUBJECT]  nvarchar(10)   primary key,
	  SUBJECT_NAME nvarchar(100) unique,
      PULPIT  nvarchar(20) foreign key references PULPIT(PULPIT)
)
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
	values	('СУБД', 'Системы управления базами данных', 'ИСиТ'),
			('БД', 'Базы данных','ИСиТ'),
			('ИНФ', 'Информационные технологии','ИСиТ'),
			('ОАиП', 'Основы алгоритмизации и программирования', 'ИСиТ'),
			('ПЗ', 'Представление знаний в компьютерных системах', 'ИСиТ'),
			('ПСП', 'Программирование сетевых приложений','ИСиТ'),
			('МСОИ', 'Моделирование систем обработки информации', 'ИСиТ'),
			('ПИС', 'Проектирование информационных систем', 'ИСиТ'),
			('КГ', 'Компьютерная геометрия ','ИСиТ'),
			('КМС', 'Компьютерные мультимедийные системы', 'ИСиТ'),
			('ДМ', 'Дискретная математика', 'ИСиТ'),
			('МП', 'Математическое программирование','ИСиТ'),
			('ЛЭВМ', 'Логические основы ЭВМ',  'ИСиТ'),
			('ООП', 'Объектно-ориентированное программирование', 'ИСиТ'),
			('ЭП', 'Экономика природопользования','МиЭП'),
			('ЭТ', 'Экономическая теория','ЭТиМ'),
			('ОСПиЛПХ','Основы садово-паркового и лесопаркового хозяйства',  'ЛПиСПС'),
			('ИГ', 'Инженерная геодезия ','ЛУ'),
			('ЛВ', 'Лесоводство', 'ЛЗиДВ'),
			('ОХ', 'Органическая химия', 'ОХ'),
			('ВТЛ', 'Водный транспорт леса','ТЛ'),
			('ТиОЛ', 'Технология и оборудование лесозаготовок', 'ЛМиЛЗ'),
			('ТОПИ', 'Технология обогащения полезных ископаемых ','ТНВиОХТ'),
			('ПМАПЛ', 'Полиграф. машины, автоматы и поточные линии', 'ПОиСОИ'),
			('ОПП', 'Организация полиграф. производства', 'ПОиСОИ');



create table GROUPS
(   IDGROUP  int identity(1,1)  primary key,				
    FACULTY   nvarchar(10) foreign key references FACULTY(FACULTY),
    PROFESSION  nvarchar(20) foreign key references PROFESSION(PROFESSION),
    YEAR_FIRST  smallint  check (YEAR_FIRST<=YEAR(GETDATE())),
);
insert into GROUPS   (FACULTY,  PROFESSION, YEAR_FIRST )
	values	('ИДиП','1-40 01 02', 2013), --1
			('ИДиП','1-40 01 02', 2012),
			('ИДиП','1-40 01 02', 2011),
			('ИДиП','1-40 01 02', 2010),
			('ИДиП','1-47 01 01', 2013),---5 гр
			('ИДиП','1-47 01 01', 2012),
			('ИДиП','1-47 01 01', 2011),
			('ИДиП','1-36 06 01', 2010),-----8 гр
			('ИДиП','1-36 06 01', 2013),
			('ИДиП','1-36 06 01', 2012),
			('ИДиП','1-36 06 01', 2011),
			('ХТиТ','1-36 01 08', 2013),---12 гр
			('ХТиТ','1-36 01 08', 2012),
			('ХТиТ','1-36 07 01', 2011),
			('ХТиТ','1-36 07 01', 2010),
			('ТОВ','1-48 01 02', 2012), ---16 гр
			('ТОВ','1-48 01 02', 2011),
			('ТОВ','1-48 01 05', 2013),
			('ТОВ','1-54 01 03', 2012),
			('ЛХФ','1-75 01 01', 2013),--20 гр
			('ЛХФ','1-75 02 01', 2012),
			('ЛХФ','1-75 02 01', 2011),
			('ЛХФ','1-89 02 02', 2012),
			('ЛХФ','1-89 02 02', 2011),
			('ТТЛП','1-36 05 01', 2013),
			('ТТЛП','1-36 05 01', 2012),
			('ТТЛП','1-46 01 01', 2012),--27 гр
			('ИЭФ','1-25 01 07', 2013),
			('ИЭФ','1-25 01 07', 2012),
			('ИЭФ','1-25 01 07', 2010),
			('ИЭФ','1-25 01 08', 2013),
			('ИЭФ','1-25 01 08', 2012); ---32 гр


create table STUDENT
(    IDSTUDENT   int  identity(1000,1) primary key,
      IDGROUP   int   foreign key references GROUPS(IDGROUP),
      [NAME]   nvarchar(100),
      BDAY   date,
      STAMP  int,
      INFO     xml,
      FOTO    nvarchar(20)
 );
insert into STUDENT (IDGROUP,[NAME], BDAY)
	values	(1, 'Хартанович Екатерина Александровна','11.03.1995'),
			(1, 'Горбач Елизавета Юрьевна',		  '07.12.1995'),
			(1, 'Зыкова Кристина Дмитриевна',     '12.10.1995'),
			(1, 'Шенец Екатерина Сергеевна',      '08.01.1995'),
			(1, 'Шитик Алина Игоревна',			  '02.08.1995'),
			(2, 'Силюк Валерия Ивановна',         '12.07.1994'),
			(2, 'Сергель Виолетта Николаевна',    '06.03.1994'),
			(2, 'Добродей Ольга Анатольевна',     '09.11.1994'),
			(2, 'Подоляк Мария Сергеевна',        '04.10.1994'),
			(2, 'Никитенко Екатерина Дмитриевна', '08.01.1994'),
			(3, 'Яцкевич Галина Иосифовна',       '02.08.1993'),
			(3, 'Осадчая Эла Васильевна',         '07.12.1993'),
			(3, 'Акулова Елена Геннадьевна',      '02.12.1993'),
			(4, 'Плешкун Милана Анатольевна',     '08.03.1992'),
			(4, 'Буянова Мария Александровна',    '02.06.1992'),
			(4, 'Харченко Елена Геннадьевна',     '11.12.1992'),
			(4, 'Крученок Евгений Александрович', '11.05.1992'),
			(4, 'Бороховский Виталий Петрович',   '09.11.1992'),
			(4, 'Мацкевич Надежда Валерьевна',    '01.11.1992'),
			(5, 'Логинова Мария Вячеславовна',    '08.07.1995'),
			(5, 'Белько Наталья Николаевна',      '02.11.1995'),
			(5, 'Селило Екатерина Геннадьевна',   '07.05.1995'),
			(5, 'Дрозд Анастасия Андреевна',      '04.08.1995'),
			(6, 'Козловская Елена Евгеньевна',    '08.11.1994'),
			(6, 'Потапнин Кирилл Олегович',       '02.03.1994'),
			(6, 'Равковская Ольга Николаевна',    '04.06.1994'),
			(6, 'Ходоронок Александра Вадимовна', '09.11.1994'),
			(6, 'Рамук Владислав Юрьевич',        '04.07.1994'),
			(7, 'Неруганенок Мария Владимировна', '03.01.1993'),
			(7, 'Цыганок Анна Петровна',          '12.09.1993'),
			(7, 'Масилевич Оксана Игоревна',      '12.06.1993'),
			(7, 'Алексиевич Елизавета Викторовна','09.02.1993'),
			(7, 'Ватолин Максим Андреевич',       '04.07.1993'),
			(8, 'Синица Валерия Андреевна',       '08.01.1992'),
			(8, 'Кудряшова Алина Николаевна',     '12.05.1992'),
			(8, 'Мигулина Елена Леонидовна',      '08.11.1992'),
			(8, 'Шпиленя Алексей Сергеевич',      '12.03.1992'),
			(9, 'Астафьев Игорь Александрович',   '10.08.1995'),
			(9, 'Гайтюкевич Андрей Игоревич',     '02.05.1995'),
			(9, 'Рученя Наталья Александровна',   '08.01.1995'),
			(9, 'Тарасевич Анастасия Ивановна',   '11.09.1995'),
			(10, 'Жоглин Николай Владимирович',   '08.01.1994'),
			(10, 'Санько Андрей Дмитриевич',      '11.09.1994'),
			(10, 'Пещур Анна Александровна',      '06.04.1994'),
			(10, 'Бучалис Никита Леонидович',     '12.08.1994'),
			(11, 'Лавренчук Владислав Николаевич','07.11.1993'),
			(11, 'Власик Евгения Викторовна',     '04.06.1993'),
			(11, 'Абрамов Денис Дмитриевич',      '10.12.1993'),
			(11, 'Оленчик Сергей Николаевич',     '04.07.1993'),
			(11, 'Савинко Павел Андреевич',       '08.01.1993'),
			(11, 'Бакун Алексей Викторович',      '02.09.1993'),
			(12, 'Бань Сергей Анатольевич',       '11.12.1995'),
			(12, 'Сечейко Илья Александрович',    '10.06.1995'),
			(12, 'Кузмичева Анна Андреевна',      '09.08.1995'),
			(12, 'Бурко Диана Францевна',         '04.07.1995'),
			(12, 'Даниленко Максим Васильевич',   '08.03.1995'),
			(12, 'Зизюк Ольга Олеговна',          '12.09.1995'),
			(13, 'Шарапо Мария Владимировна',     '08.10.1994'),
			(13, 'Касперович Вадим Викторович',   '10.02.1994'),
			(13, 'Чупрыгин Арсений Александрович','11.11.1994'),
			(13, 'Воеводская Ольга Леонидовна',   '10.02.1994'),
			(13, 'Метушевский Денис Игоревич',    '12.01.1994'),
			(14, 'Ловецкая Валерия Александровна','11.09.1993'),
			(14, 'Дворак Антонина Николаевна',    '01.12.1993'),
			(14, 'Щука Татьяна Николаевна',       '09.06.1993'),
			(14, 'Коблинец Александра Евгеньевна','05.01.1993'),
			(14, 'Фомичевская Елена Эрнестовна',  '01.07.1993'),
			(15, 'Бесараб Маргарита Вадимовна',   '07.04.1992'),
			(15, 'Бадуро Виктория Сергеевна',     '10.12.1992'),
			(15, 'Тарасенко Ольга Викторовна',    '05.05.1992'),
			(15, 'Афанасенко Ольга Владимировна', '11.01.1992'),
			(15, 'Чуйкевич Ирина Дмитриевна',     '04.06.1992'),
			(16, 'Брель Алеся Алексеевна',        '08.01.1994'),
			(16, 'Кузнецова Анастасия Андреевна', '07.02.1994'),
			(16, 'Томина Карина Геннадьевна',     '12.06.1994'),
			(16, 'Дуброва Павел Игоревич',        '03.07.1994'),
			(16, 'Шпаков Виктор Андреевич',       '04.07.1994'),
			(17, 'Шнейдер Анастасия Дмитриевна',  '08.11.1993'),
			(17, 'Шыгина Елена Викторовна',       '02.04.1993'),
			(17, 'Клюева Анна Ивановна',          '03.06.1993'),
			(17, 'Доморад Марина Андреевна',      '05.11.1993'),
			(17, 'Линчук Михаил Александрович',   '03.07.1993'),
			(18, 'Васильева Дарья Олеговна',      '08.01.1995'),
			(18, 'Щигельская Екатерина Андреевна','06.09.1995'),
			(18, 'Сазонова Екатерина Дмитриевна', '08.03.1995'),
			(18, 'Бакунович Алина Олеговна',      '07.08.1995');



create table PROGRESS
(  SUBJECT   nvarchar(10) foreign key  references SUBJECT([SUBJECT]),
     IDSTUDENT int   foreign key references STUDENT(IDSTUDENT),
     PDATE    date,
     NOTE     int check (NOTE between 1 and 10)
);
insert into PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
    values ('ОАиП', 1001,  '01.10.2013',8),
           ('ОАиП', 1002,  '01.10.2013',7),
           ('ОАиП', 1003,  '01.10.2013',5),
           ('ОАиП', 1005,  '01.10.2013',4),
		   ('СУБД', 1014,  '01.12.2013',5),
           ('СУБД', 1015,  '01.12.2013',9),
           ('СУБД', 1016,  '01.12.2013',5),
           ('СУБД', 1017,  '01.12.2013',4),
		   ('КГ',   1018,  '06.5.2013',4),
           ('КГ',   1019,  '06.05.2013',7),
           ('КГ',   1020,  '06.05.2013',7),
           ('КГ',   1021,  '06.05.2013',9),
           ('КГ',   1022,  '06.05.2013',5),
           ('КГ',   1023,  '06.05.2013',6);