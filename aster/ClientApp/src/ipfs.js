//Config file for using ipfs through infuria instead of hosting a local node.

import IPFS from 'ipfs-http-client'

const ipfs = new IPFS({
    host: 'ipfs.infura.io',
    port: '5001',
    protocol: 'https'
});

export default ipfs; 