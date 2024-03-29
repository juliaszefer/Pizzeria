const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = 'http://localhost:5203';

const context = [
  "/Adres",
  "/Dodatek",
  "/DodatekTlumaczenie",
  "/Napoj",
  "/NapojTlumaczenie",
  "/Osoba",
  "/Pizza",
  "/PizzaTlumaczenie",
  "/Rola",
  "/Skladnik",
  "/Uzytkownik",
  "/Zamowienie"  
];

const onError = (err, req, resp, target) => {
    console.error(`${err.message}`);
}

module.exports = function (app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    // Handle errors to prevent the proxy middleware from crashing when
    // the ASP NET Core webserver is unavailable
    onError: onError,
    secure: false,
    // Uncomment this line to add support for proxying websockets
    //ws: true, 
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
