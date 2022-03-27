-- Table: public.Employee

DROP TABLE IF EXISTS public.employee;

CREATE TABLE IF NOT EXISTS public.employee
(
    "id" bigint NOT NULL,
    "firstname" character varying COLLATE pg_catalog."default",
    "lastname" character varying COLLATE pg_catalog."default",
    "dateofbirth" date,
    CONSTRAINT "Employee_pkey" PRIMARY KEY ("id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.employee
    OWNER to postgres;

-- Functions

CREATE OR REPLACE FUNCTION employee_getbyid_v1(p_id bigint)
RETURNS TABLE(id bigint, firstname character varying, lastname character varying, dateofbirth date)
AS $$
    BEGIN
         RETURN QUERY
			 SELECT employee.id, employee.firstname, employee.lastname, employee.dateofbirth 
             FROM employee
             WHERE employee.id = p_id;
    END;
$$  LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION employee_getbydateofbirth_v1(p_dob character varying)
RETURNS TABLE(id bigint, firstname character varying, lastname character varying, dateofbirth date)
AS $$
	DECLARE
		search_date date;
    BEGIN
		search_date := date(p_dob);
        RETURN QUERY
			 SELECT employee.id, employee.firstname, employee.lastname, employee.dateofbirth 
             FROM employee
             WHERE employee.dateofbirth = search_date;
    END;
$$  LANGUAGE plpgsql;

-- Insert some dummy data

INSERT INTO public.employee(
	"id", "firstname", "lastname", "dateofbirth")
	VALUES (1, 'John', 'Doe', '1999-01-08');

INSERT INTO public.employee(
	"id", "firstname", "lastname", "dateofbirth")
	VALUES (2, 'John', 'Smith', '1999-01-08');

INSERT INTO public.employee(
	"id", "firstname", "lastname", "dateofbirth")
	VALUES (3, 'Fox', 'Finch', '1990-01-08');
