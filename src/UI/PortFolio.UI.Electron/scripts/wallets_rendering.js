const walletRefreshButton = document.getElementById('refreshWallets')
const walletView = document.getElementById('walletsView');

const stockPairsButton = document.getElementById('refreshStockPairs');
const stockPairsView = document.getElementById('stockPairs');


walletRefreshButton.onclick = ReloadWallets;
stockPairsButton.onclick = ReloadStockPairs;


async function ReloadWallets(){
    axios.get('https://localhost:8796/wallets')
    .then(function (response) {
        console.log(response);
        var wallets = response.data;
        walletView.textContent = ''
        wallets.forEach(function (item) {
            let li = document.createElement('li');
            li.innerHTML += item.walletName
            walletView.appendChild(li);
            })
        })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
      .then(function () {
        // always executed
      });
    }

      async function ReloadStockPairs(){
        axios.get('https://localhost:8796/StocksValue')
        .then(function (response) {
            console.log(response);
            var stocksValues = response.data;
            stockPairsView.textContent = ''
            stocksValues.forEach(function (item) {
                let li = document.createElement('li');
                li.innerHTML += `<b>${item.stock}</b> ${item.valueInCurrency} ${item.currency}`;
                stockPairsView.appendChild(li);
                })
            })
          .catch(function (error) {
            // handle error
            console.log(error);
          })
          .then(function () {
            // always executed
          });
    
}