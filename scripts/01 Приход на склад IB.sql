
 /*------   ------*/
 SET TERM ~~~ ;
 create procedure SP_ADDLOT_FROMSQL (
    VENDOR_ID integer,
    STOCK_ID integer,
    LOT_DOCDATE date,
    LOT_SRCCODE integer,
    LOT_SRCID integer,
    LOT_NUM varchar(16),
    LOT_DOCNUM varchar(16),
    LOT_WAYBILLNUM varchar(16),
    LOT_ALLPRICE double precision,
    CURRENCY_CODE char(3),
    LOT_CURRENCYRATE double precision,
    LOT_CURRENCYALLPRICE double precision,
    LOT_VENDORMARKUP double precision,
    LOT_CURRENCYALLVENDORPRICE double precision,
    LOT_EURRATE double precision)
returns (
    LOT_ID integer,
    ERROR_NUMBER integer,
    ERROR_TEXT varchar(480))
as
declare variable LOT_STATE integer;
declare variable LOT_DATE date;
declare variable LOT_SHIPDATE date;
declare variable LOT_STOCKDATE date;
declare variable LOT_ACCEPTDATE date;
BEGIN
 ERROR_NUMBER = -1;
 ERROR_TEXT = '';
 LOT_ID = null; /* код сохраненного прихода */

 LOT_DATE = :LOT_DOCDATE;
 LOT_SHIPDATE = :LOT_DOCDATE;
 LOT_STOCKDATE = :LOT_DOCDATE;
 LOT_ACCEPTDATE = :LOT_DOCDATE;
 LOT_STATE = 0;

 LOT_ID = gen_id( g_lotid, 1);

 execute procedure SP_ADDLOT ( :LOT_ID, :VENDOR_ID, :STOCK_ID, :LOT_SRCCODE, :LOT_SRCID,
    :LOT_DATE, :LOT_NUM, :LOT_SHIPDATE, :LOT_STOCKDATE, :LOT_DOCNUM, :LOT_DOCDATE,
    :LOT_ACCEPTDATE, :LOT_WAYBILLNUM, :LOT_ALLPRICE, :CURRENCY_CODE, :LOT_CURRENCYRATE,
    :LOT_CURRENCYALLPRICE, :LOT_VENDORMARKUP, :LOT_CURRENCYALLVENDORPRICE, :LOT_EURRATE);

 ERROR_NUMBER = 0;
 ERROR_TEXT = cast( ( 'Успешное завершение операции. Код прихода: ' || cast( :LOT_ID as varchar(8) ) ) as varchar(480));

 suspend;

 WHEN ANY DO
  BEGIN
   LOT_ID = null;
   ERROR_NUMBER = -1;
   ERROR_TEXT = cast( ( :ERROR_TEXT || ' Не удалось сохранить приход. Неизвестная ошибка, т.к не удается вернуть SQLCODE.' ) as varchar(480));

   suspend;
  END

END
  ~~~
 SET TERM ; ~~~
 commit work;

 /*------   ------*/
 SET TERM ~~~ ;
  create procedure SP_ADDLOTITMS_FROMSQL (
    LOT_ID integer,
    PARTS_ID integer,
    MEASURE_ID integer,
    LOTITMS_QUANTITY integer,
    LOTITMS_PRICE double precision,
    LOTITMS_CURRENCYPRICE double precision,
    LOTITMS_VENDORMARKUP double precision,
    COUNTRY_ID integer,
    LOTITMS_EXPDATE date)
returns (
    LOTITMS_ID integer,
    ERROR_NUMBER integer,
    ERROR_TEXT varchar(480))
as
declare variable LOTITMS_COURSE double precision;
declare variable LOTITMS_ORDERQTY integer;
declare variable LOTITMS_WAYBILLQTY integer;
declare variable LOTITMS_PACKID integer;
declare variable LOTITMS_CURRENCYPRICE2 double precision;
declare variable LOTITMS_CURRENCYVENDORPRICE double precision;
declare variable LOTITMS_INVOICEPRICE double precision;
declare variable LOTITMS_CUSTOMTARIFF double precision;
BEGIN
 ERROR_NUMBER = -1;
 ERROR_TEXT = '';
 LOTITMS_ID = null; /* код сохраненной записи в приложении к приходу */
 LOTITMS_COURSE = 0;
 LOTITMS_ORDERQTY = :LOTITMS_QUANTITY;
 LOTITMS_WAYBILLQTY = :LOTITMS_QUANTITY;
 LOTITMS_PACKID = :MEASURE_ID;
 LOTITMS_CURRENCYPRICE2 = 0;
 LOTITMS_CURRENCYVENDORPRICE = :LOTITMS_PRICE;


 LOTITMS_INVOICEPRICE = 0;
 LOTITMS_CUSTOMTARIFF = 0;

 LOTITMS_ID = gen_id( g_lotitmsid, 1 );

 /* вставка записи в приложение к приходу */
 INSERT INTO t_LOTITMS ( LOTITMS_ID, lot_id, parts_id, measure_id,  lotitms_orderqty, lotitms_waybillqty, lotitms_quantity, lotitms_packid,
  lotitms_price, lotitms_currencyprice, lotitms_currencyprice2,
  lotitms_vendormarkup, LOTITMS_CURRENCYVENDORPRICE, lotitms_course, LOTITMS_EXPDATE,
  LOTITMS_CUSTOMTARIFF, COUNTRY_ID, LOTITMS_INVOICEPRICE )
 VALUES( :LOTITMS_ID, :lot_id, :parts_id, :measure_id, :lotitms_orderqty, :lotitms_waybillqty, :lotitms_quantity, :lotitms_packid,
  :lotitms_price, :lotitms_currencyprice, :lotitms_currencyprice2,
  :lotitms_vendormarkup, :LOTITMS_CURRENCYVENDORPRICE, :lotitms_course, :LOTITMS_EXPDATE,
  :LOTITMS_CUSTOMTARIFF, :COUNTRY_ID, :LOTITMS_INVOICEPRICE );

 ERROR_NUMBER = 0;
 ERROR_TEXT = cast( ( 'Успешное завершение операции. Код строки заказа: ' || cast( :LOTITMS_ID as varchar(8) ) ) as varchar(480));

 suspend;

 WHEN ANY DO
  BEGIN
   DELETE FROM T_LOTITMS WHERE LOT_ID = :LOT_ID;
   DELETE FROM T_LOT WHERE LOT_ID = :LOT_ID;

   ERROR_NUMBER = -1;
   ERROR_TEXT = cast( ( :ERROR_TEXT || ' Не удалось строку в приложении к заказу. Неизвестная ошибка, т.к не удается вернуть SQLCODE.' ) as varchar(480));

   suspend;
  END

END
  ~~~
 SET TERM ; ~~~
 commit work;

 /*------   ------*/
 SET TERM ~~~ ;
 create procedure SP_CREATEINSTOCK_FROMLOT (
    LOT_ID integer)
returns (
    ERROR_NUMBER integer,
    ERROR_TEXT varchar(480))
as
 declare variable STOCK_ID integer;
 declare variable INSTOCK_ID integer;
 declare variable INSTOCK_SRCCODE integer;
 declare variable INSTOCK_SRCID integer;
 declare variable PARTS_ID integer;
 declare variable MEASURE_ID integer;
 declare variable INSTOCK_PRICE double precision;
 declare variable INSTOCK_CURRENTQTY integer;
 declare variable LOTITMS_ID integer;
 declare variable CARDS_OPERDOC varchar(16);
 declare variable CARDS_SHIPDATE date;
 declare variable LOT_WAYBILLNUM varchar(16);
 declare variable LOTITMS_PRICE double precision;
 declare variable LOTITMS_QUANTITY integer;

 declare variable COMPANY_ID integer;
 declare variable COMPANY_NAME varchar(32);
 declare variable LOT_DOCDATE date;
 declare variable LOT_DOCNUM varchar(16);
 declare variable LOT_ALLPRICE double precision;
 declare variable STOREWAYBILL_ID integer;
 declare variable STOREWAYBILL_SRCCODE integer;
 declare variable STOREWAYBILL_SRCID integer;
 declare variable STOREWAYBILL_NUM varchar(16);
 declare variable STOREWAYBILL_BEGINDATE date;
 declare variable STOREWAYBILL_SHIPDATE date;
 declare variable STOREWAYBILL_SHIPPED integer;
 declare variable STOREWAYBILL_CUSTOMERNAME varchar(32);
 declare variable STOREWAYBILL_QTY integer;
 declare variable STOREWAYBILL_ALLPRICE double precision;
 declare variable STOREWAYBITMS_SRCID integer;
 declare variable STOREWAYBITMS_QUANTITY integer;
 declare variable STOREWAYBITMS_PRICE double precision;
 declare variable STOREWAYBITMS_BASEPRICE double precision;

BEGIN
 ERROR_NUMBER = -1;
 ERROR_TEXT = '';

 if (not exists ( select lot_id from t_lot where lot_id = :lot_id ) ) then
  begin
   ERROR_NUMBER = 1;
   ERROR_TEXT = cast( ( :ERROR_TEXT || ' Не найден документ с указанным кодом. Обратитесь к разработчику. Код документа: ' || cast( :LOT_ID as varchar(16) ) ) as varchar(480));

   suspend;
  end

 select STOCK_ID, LOT_DOCDATE, LOT_DOCNUM, LOT_WAYBILLNUM, LOT_ALLPRICE
 from t_lot where lot_id =  :LOT_ID
 into :STOCK_ID, :LOT_DOCDATE, :LOT_DOCNUM, :LOT_WAYBILLNUM, :LOT_ALLPRICE;

 select sum( lotitms.lotitms_leavqty )
 from t_lotitms lotitms
 where lotitms.lot_id = :lot_id
 into :STOREWAYBILL_QTY;

 select stock.company_id, company.company_name
 from t_stock stock, t_company company
 where stock.stock_id = :STOCK_ID
   and stock.company_id = company.company_id
 into :company_id, :company_name;

 /* регистрация документа "Накладная на ответ хранение" */
 STOREWAYBILL_ID = gen_id( g_storewaybillid, 1);
 STOREWAYBILL_SRCCODE = 0;
 STOREWAYBILL_SRCID = :LOT_ID;
 STOREWAYBILL_NUM = :LOT_WAYBILLNUM;
 STOREWAYBILL_BEGINDATE = :LOT_DOCDATE;
 STOREWAYBILL_SHIPDATE = NULL;
 STOREWAYBILL_SHIPPED = 0;
 STOREWAYBILL_CUSTOMERNAME = :COMPANY_NAME;
 STOREWAYBILL_ALLPRICE = :LOT_ALLPRICE;

 execute procedure SP_ADDSTOREWAYBILL ( :COMPANY_ID, :STOREWAYBILL_ID, :STOREWAYBILL_SRCCODE,
    :STOREWAYBILL_SRCID, :STOREWAYBILL_NUM, :STOREWAYBILL_BEGINDATE, :STOREWAYBILL_SHIPDATE,
    :STOREWAYBILL_SHIPPED, :STOREWAYBILL_CUSTOMERNAME, :STOREWAYBILL_QTY, :STOREWAYBILL_ALLPRICE );

 /* для каждой записи в приходе формируется остаток и запись в приложении к накладной на ответственное хранение */
 for select lotitms.lotitms_id, lotitms.parts_id, lotitms.measure_id,
  lotitms.lotitms_quantity, lotitms.lotitms_price
 from t_lotitms lotitms
 where lotitms.lot_id = :LOT_ID
 into :lotitms_id, :parts_id, :measure_id,  :lotitms_quantity, :lotitms_price
  do
   begin
    /* формирование остатка */
    INSTOCK_SRCCODE = 1;
    INSTOCK_SRCID = :lotitms_id;
    INSTOCK_PRICE = :lotitms_price;
    INSTOCK_CURRENTQTY = :lotitms_quantity;
    LOTITMS_ID = :lotitms_id;
    CARDS_OPERDOC = :LOT_DOCNUM;
    CARDS_SHIPDATE = :LOT_DOCDATE;

    execute procedure SP_CREATEINSTOCK ( :STOCK_ID, :INSTOCK_SRCCODE, :INSTOCK_SRCID, :PARTS_ID, :INSTOCK_PRICE,
     :INSTOCK_CURRENTQTY, :LOTITMS_ID, :CARDS_OPERDOC, :CARDS_SHIPDATE );

    /* приложение к накладной на отвественное хранение */
    STOREWAYBITMS_SRCID = :lotitms_id;
    STOREWAYBITMS_QUANTITY = :lotitms_quantity;
    STOREWAYBITMS_PRICE = :lotitms_price;
    select price0 from t_prices where parts_id = :parts_id
    into :STOREWAYBITMS_BASEPRICE;
    if( :STOREWAYBITMS_BASEPRICE is null ) then STOREWAYBITMS_BASEPRICE = 0;

    execute procedure SP_ADDSTOREWAYBITMS( :STOREWAYBILL_ID, :STOREWAYBITMS_SRCID,
     :PARTS_ID, :MEASURE_ID, :STOREWAYBITMS_QUANTITY, :STOREWAYBITMS_PRICE, :STOREWAYBITMS_BASEPRICE );
   end

 ERROR_NUMBER = 0;
 ERROR_TEXT = cast( ( 'Успешное завершение операции. Код прихода: ' || cast( :LOT_ID as varchar(8) ) ) as varchar(480));

 suspend;

 WHEN ANY DO
  BEGIN
   /* удаляется информация в остатке, карточке движения и в наладных на ответственное хранение */
   delete from t_storewaybitms where storewaybill_id = :storewaybill_id;
   delete from t_storewaybill where storewaybill_id = :storewaybill_id;

   for select instock_id from t_instock
   where lotitms_id in ( select lotitms_id from t_lotitms where lot_id = :lot_id )
   into :instock_id
    do
     if( :instock_id is not null ) then
      delete from t_cards where instock_id = :instock_id;

   delete from t_instock where lotitms_id in (  select lotitms_id from t_lotitms where lot_id = lot_id  );

   delete from t_lotitms where lot_id = :lot_id;
   delete from t_lot where lot_id = :lot_id;

   ERROR_NUMBER = -1;
   ERROR_TEXT = cast( ( :ERROR_TEXT || ' Не удалось поставить товар на приход. Обратитесь к разработчику. Код документа: ' || cast( :LOT_ID as varchar(16) ) ) as varchar(480));

   suspend;
  END

END
  ~~~
 SET TERM ; ~~~
 commit work;
