--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: aggregate_info(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.aggregate_info() RETURNS TABLE(parameter character varying, value text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Средняя стоимость услуги за химчистку
    RETURN QUERY SELECT
        'Средняя стоимость услуги'::VARCHAR, AVG(cost)::TEXT
    FROM
        orders;

    -- Минимальный и максимальный стаж сотрудника
    RETURN QUERY SELECT
        'Минимальный стаж сотрудника'::VARCHAR, MIN(experience)::TEXT
    FROM
        employees;

    RETURN QUERY SELECT
        'Максимальный стаж сотрудника'::VARCHAR, MAX(experience)::TEXT
    FROM
        employees;

    -- Количество клиентов
    RETURN QUERY SELECT
        'Количество клиентов'::VARCHAR, COUNT(*)::TEXT
    FROM
        clients;
END;
$$;


ALTER FUNCTION public.aggregate_info() OWNER TO postgres;

--
-- Name: delete_client(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.delete_client(IN client_passport bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM items WHERE order_id IN (
        SELECT id FROM orders WHERE passport = delete_client.client_passport
    );
    DELETE FROM orders WHERE passport = delete_client.client_passport;
    DELETE FROM clients WHERE passport = delete_client.client_passport;
END;
$$;


ALTER PROCEDURE public.delete_client(IN client_passport bigint) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: addresses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.addresses (
    id smallint NOT NULL,
    name character varying(50) NOT NULL,
    address character varying(150) NOT NULL
);


ALTER TABLE public.addresses OWNER TO postgres;

--
-- Name: addresses_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.addresses_id_seq
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.addresses_id_seq OWNER TO postgres;

--
-- Name: addresses_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.addresses_id_seq OWNED BY public.addresses.id;


--
-- Name: clients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clients (
    passport bigint NOT NULL,
    fullname character varying(50) NOT NULL,
    phonenumber character varying(15) NOT NULL,
    discount smallint
);


ALTER TABLE public.clients OWNER TO postgres;

--
-- Name: clients_discount_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clients_discount_seq
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.clients_discount_seq OWNER TO postgres;

--
-- Name: clients_discount_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clients_discount_seq OWNED BY public.clients.discount;


--
-- Name: clients_passport_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clients_passport_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.clients_passport_seq OWNER TO postgres;

--
-- Name: clients_passport_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clients_passport_seq OWNED BY public.clients.passport;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    id integer NOT NULL,
    fullname character varying(50) NOT NULL,
    experience smallint NOT NULL
);


ALTER TABLE public.employees OWNER TO postgres;

--
-- Name: employees_experience_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employees_experience_seq
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employees_experience_seq OWNER TO postgres;

--
-- Name: employees_experience_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employees_experience_seq OWNED BY public.employees.experience;


--
-- Name: employees_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employees_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employees_id_seq OWNER TO postgres;

--
-- Name: employees_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employees_id_seq OWNED BY public.employees.id;


--
-- Name: items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.items (
    order_id integer NOT NULL,
    item_id integer NOT NULL,
    clothtype character varying(50) NOT NULL,
    fabrictype character varying(50) NOT NULL,
    color character varying(50) NOT NULL
);


ALTER TABLE public.items OWNER TO postgres;

--
-- Name: items_item_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.items_item_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.items_item_id_seq OWNER TO postgres;

--
-- Name: items_item_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.items_item_id_seq OWNED BY public.items.item_id;


--
-- Name: items_order_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.items_order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.items_order_id_seq OWNER TO postgres;

--
-- Name: items_order_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.items_order_id_seq OWNED BY public.items.order_id;


--
-- Name: orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.orders (
    id integer NOT NULL,
    employee_id integer NOT NULL,
    passport bigint NOT NULL,
    address_id smallint NOT NULL,
    date timestamp with time zone DEFAULT now() NOT NULL,
    status character varying(30) NOT NULL,
    cost integer NOT NULL
);


ALTER TABLE public.orders OWNER TO postgres;

--
-- Name: orders_address_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_address_id_seq
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orders_address_id_seq OWNER TO postgres;

--
-- Name: orders_address_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_address_id_seq OWNED BY public.orders.address_id;


--
-- Name: orders_employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_employee_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orders_employee_id_seq OWNER TO postgres;

--
-- Name: orders_employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_employee_id_seq OWNED BY public.orders.employee_id;


--
-- Name: orders_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orders_id_seq OWNER TO postgres;

--
-- Name: orders_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_id_seq OWNED BY public.orders.id;


--
-- Name: orders_passport_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_passport_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orders_passport_seq OWNER TO postgres;

--
-- Name: orders_passport_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_passport_seq OWNED BY public.orders.passport;


--
-- Name: ordersummary; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.ordersummary AS
 SELECT o.id AS "Идентификатор заказа",
    i.clothtype AS "Вид одежды",
    i.fabrictype AS "Тип ткани",
    i.color AS "Цвет предмета",
    e.fullname AS "ФИО сотрудника",
    e.experience AS "Стаж сотрудника (лет)",
    c.passport AS "№ паспорта клиента",
    c.fullname AS "ФИО клиента",
    c.phonenumber AS "Телефон клиента",
    c.discount AS "Скидка клиента (%)",
    o.date AS "Дата принятия заказа",
    o.status AS "Статус заказа",
    o.cost AS "Стоимость услуг (руб.)",
    a.name AS "Название",
    a.address AS "Адрес"
   FROM ((((public.orders o
     JOIN public.employees e ON ((o.employee_id = e.id)))
     JOIN public.clients c ON ((o.passport = c.passport)))
     JOIN public.addresses a ON ((o.address_id = a.id)))
     JOIN public.items i ON ((o.id = i.order_id)));


ALTER TABLE public.ordersummary OWNER TO postgres;

--
-- Name: addresses id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.addresses ALTER COLUMN id SET DEFAULT nextval('public.addresses_id_seq'::regclass);


--
-- Name: clients passport; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients ALTER COLUMN passport SET DEFAULT nextval('public.clients_passport_seq'::regclass);


--
-- Name: employees id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN id SET DEFAULT nextval('public.employees_id_seq'::regclass);


--
-- Name: employees experience; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN experience SET DEFAULT nextval('public.employees_experience_seq'::regclass);


--
-- Name: orders id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN id SET DEFAULT nextval('public.orders_id_seq'::regclass);


--
-- Name: orders employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN employee_id SET DEFAULT nextval('public.orders_employee_id_seq'::regclass);


--
-- Name: orders passport; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN passport SET DEFAULT nextval('public.orders_passport_seq'::regclass);


--
-- Name: orders address_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN address_id SET DEFAULT nextval('public.orders_address_id_seq'::regclass);


--
-- Data for Name: addresses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.addresses (id, name, address) FROM stdin;
1	Чистюля	г. Москва, ул. Сибирская, д. 12
3	ЭкоКреатив	г. Москва, ул. Зелёная, д. 1
4	Блеск и Чистота	г. Москва, ул. Юрша, д. 4
5	Чистые ткани	г. Москва, ул. Волкова, д. 50
6	Гармония чистоты	г. Москва, ул. Ленина, д. 26
7	Чистопляс	г. Москва, ул. Целинная, д. 98
8	Шик-Шик	г. Москва, ул. Чернышевского, д. 15
9	Мегастиральня	г. Москва, ул. Красная, д. 75
10	Гладиатор Чистоты	г. Москва, ул. Молчанова, д. 8
2	Отмывайка	г. Москва, ул. Ямпольская, д. 55
\.


--
-- Data for Name: clients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clients (passport, fullname, phonenumber, discount) FROM stdin;
5712625364	Кулаков А.М.	89223548271	5
4073364758	Рогожников Д.В.	89617273283	10
5715857649	Полынский А.А.	89024556363	5
1122253748	Бородулин Е.С.	89223515270	5
1223485769	Собченко Е.А.	8996054312	15
4518243657	Хомяков У.Г.	89224756638	5
3418996722	Суматохин А.А.	89223338211	20
5710364859	Гявгянен А.А.	89023444894	5
5720444894	Наумов Н.А.	89005553535	10
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (id, fullname, experience) FROM stdin;
2	Семёнова Ю.А.	5
3	Валиев А.Д.	1
4	Полынский А.А.	2
5	Левин В.Н.	6
6	Князев А.А.	4
7	Сырков У.И.	1
8	Уликус К.К.	2
9	Головин А.Л.	6
10	Миранчук А.М.	8
1	Гявгянен А.Ф.	4
\.


--
-- Data for Name: items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.items (order_id, item_id, clothtype, fabrictype, color) FROM stdin;
3	1	Брюки	Вискоза	Синий
4	1	Шорты	Джинс	Синий
6	1	Юбка	Атлас	Бежевый
7	1	Пиджак	Шерсть	Чёрный
7	2	Юбка	Вискоза	Желтый
5	1	Пальто	Вискоза	Коричневый
7	3	Шорты	Шерсть	Синий
3	2	Плащ	Шерсть	Синий
8	1	Плащ	Шерсть	Коричневый
8	2	Плащ	Шерсть	Синий
2	1	Шорты	Вискоза	Белый
2	2	Блуза	Вискоза	Синий
7	4	Плащ	Вискоза	Коричневый
43	1	Пальто	Шерсть	Коричневый
11	1	Пальто	Шерсть	Белый
\.


--
-- Data for Name: orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.orders (id, employee_id, passport, address_id, date, status, cost) FROM stdin;
3	3	5715857649	2	2023-12-13 03:00:48.554715+05	Готов	475
4	2	1122253748	1	2023-12-13 03:00:48.554715+05	Готов	475
5	4	1223485769	2	2023-12-13 03:00:48.554715+05	Выполняется	425
6	5	4518243657	2	2023-12-13 03:00:48.554715+05	Готов	475
8	6	5712625364	5	2023-12-14 11:50:30.889588+05	Принят в обработку	0
2	5	5715857649	3	2023-12-14 11:29:26.397339+05	Принят в обработку	950
7	1	3418996722	1	2023-12-13 03:00:48.554715+05	Выполняется	1600
43	5	1122253748	3	2023-12-14 13:36:08.858673+05	Принят в обработку	475
10	4	5715857649	1	2023-12-14 15:00:41.655845+05	Принят в обработку	0
11	1	5715857649	5	2023-12-14 15:27:27.197639+05	Принят в обработку	475
13	3	1223485769	4	2023-12-14 15:33:17.165524+05	Принят в обработку	0
\.


--
-- Name: addresses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.addresses_id_seq', 1, false);


--
-- Name: clients_discount_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clients_discount_seq', 8, true);


--
-- Name: clients_passport_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clients_passport_seq', 1, false);


--
-- Name: employees_experience_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_experience_seq', 1, false);


--
-- Name: employees_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_id_seq', 1, false);


--
-- Name: items_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.items_item_id_seq', 1, false);


--
-- Name: items_order_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.items_order_id_seq', 1, false);


--
-- Name: orders_address_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_address_id_seq', 1, false);


--
-- Name: orders_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_employee_id_seq', 1, true);


--
-- Name: orders_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_id_seq', 1, false);


--
-- Name: orders_passport_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_passport_seq', 1, false);


--
-- Name: addresses addresses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.addresses
    ADD CONSTRAINT addresses_pkey PRIMARY KEY (id);


--
-- Name: clients clients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_pkey PRIMARY KEY (passport);


--
-- Name: employees employees_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_pkey PRIMARY KEY (id);


--
-- Name: items items_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.items
    ADD CONSTRAINT items_pkey PRIMARY KEY (order_id, item_id);


--
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (id);


--
-- Name: items items_order_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.items
    ADD CONSTRAINT items_order_id_fkey FOREIGN KEY (order_id) REFERENCES public.orders(id);


--
-- Name: orders orders_address_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_address_id_fkey FOREIGN KEY (address_id) REFERENCES public.addresses(id);


--
-- Name: orders orders_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employees(id);


--
-- Name: orders orders_passport_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_passport_fkey FOREIGN KEY (passport) REFERENCES public.clients(passport);


--
-- PostgreSQL database dump complete
--

