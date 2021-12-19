const {app, remote} = require('electron')
const axios = require('axios');

const btn = document.getElementById('btn')
const show = document.getElementById('Show')
btn.innerText = 'Test Me';
btn.onclick = GetPrice;

async function GetPrice(){

// Make a request for a user with a given ID
axios.get('https://localhost:8796/simpledata/Price')
.then(function (response) {
  // handle success
  console.log(response);
  show.innerHTML = response.data.symbol + ":" + response.data.price;
})
.catch(function (error) {
  // handle error
  console.log(error);
})
.then(function () {
  // always executed
});
}