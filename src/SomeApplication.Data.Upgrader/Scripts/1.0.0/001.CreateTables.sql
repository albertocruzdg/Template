CREATE TABLE public.products
(
    id uuid NOT NULL,
    code character varying(100) NOT NULL,
    name character varying(100) NOT NULL,
    description character varying(5000),
    CONSTRAINT pk_products PRIMARY KEY (id)
);

CREATE TABLE public.prices
(
    id uuid NOT NULL,
    product_id uuid NOT NULL,
    amount money NOT NULL,
    currency character varying(10) NOT NULL,
    due_date timestamp with time zone,
    CONSTRAINT pk_prices PRIMARY KEY (id),
    CONSTRAINT fk_prices_product_id FOREIGN KEY (product_id) REFERENCES public.products (id)
);

CREATE TABLE public.sales_orders
(
    id uuid NOT NULL,
    date timestamp with time zone,
    CONSTRAINT pk_sales_orders PRIMARY KEY (id)
);

CREATE TABLE public.sales_order_products
(
    id uuid NOT NULL,
    price_id uuid NOT NULL,
    quantity integer NOT NULL,
    sales_order_id uuid NOT NULL,
    CONSTRAINT sales_order_products_pkey PRIMARY KEY (id),
    CONSTRAINT fk_sales_order_products_price_id FOREIGN KEY (price_id) REFERENCES public.prices (id),
    CONSTRAINT fk_sales_order_products_sales_order_id FOREIGN KEY (sales_order_id) REFERENCES public.sales_orders (id)
)