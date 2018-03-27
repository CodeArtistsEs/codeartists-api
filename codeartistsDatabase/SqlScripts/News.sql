-- Table: public."news"

-- DROP TABLE public."news";

CREATE TABLE public."news"
(
    "news_id" bigint NOT NULL DEFAULT nextval('"News_news_id_seq"'::regclass),
    "header" text COLLATE pg_catalog."default",
    "content" text COLLATE pg_catalog."default",
    CONSTRAINT "News_pkey" PRIMARY KEY ("news_id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."News"
    OWNER to codeartists;