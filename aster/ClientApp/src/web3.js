import Web3 from 'web3';

const web3 = new Web3(window.ethereum);

try {
    window.ethereum.autoRefreshOnNetworkChange = false;
    window.ethereum.enable().then(function () {});
}

catch (e) {
}

export default web3;