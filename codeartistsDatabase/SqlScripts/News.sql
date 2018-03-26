-- Table: public."News"

-- DROP TABLE public."News";

CREATE TABLE public."News"
(
    "NewsId" bigint NOT NULL DEFAULT nextval('"News_NewsId_seq"'::regclass),
    "Header" text COLLATE pg_catalog."default",
    "Content" text COLLATE pg_catalog."default",
    CONSTRAINT "News_pkey" PRIMARY KEY ("NewsId")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."News"
    OWNER to codeartists;