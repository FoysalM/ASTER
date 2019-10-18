import React, { Component } from 'react';
import { Form } from 'react-bootstrap';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import CryptoJS from "react-native-crypto-js";

import web3 from '../../web3';
import ipfs from '../../ipfs';
import handleIPFSAddr from '../../handleIPFSAddr';

export class SubmitToIPFS extends Component {
    displayName = SubmitToIPFS.name

    //Initialise the variables.
    state = {
        a: null,
        buffer: '',
        ethAddress: '',
        transactionHash: '',
        txReceipt: ''
    };

    //Load the assignment.
    selectAssignFile = (event) => {
        event.stopPropagation()
        event.preventDefault()
        const file = event.target.files[0]
        let reader = new window.FileReader()
        console.log('reader:', reader);
        reader.readAsText(file)
        reader.onloadend = () => this.encrypt(reader)
    };

    //Encrypt the file.
    encrypt = (reader) => {
        const dataFile = (reader.result),
            //convertedToBase64 = dataFile.toString('base64'),
            encryptFile = CryptoJS.AES.encrypt(dataFile, "Secret"),
            buffer = new Buffer(encryptFile.toString());
        //console.log('convertedToBase64:', convertedToBase64);
        console.log('dataFile:', dataFile);
        console.log('encryptFile:', encryptFile);
        console.log('buffer:', buffer);
        this.setState({ buffer });
    };

    viewOnRinkeby = () => {
        const ethscan = this.state.transactionHash;
        window.open('https://rinkeby.etherscan.io/tx/' + ethscan);
    };

    dlFromIPFS = () => {
        const ipfsAdd = this.state.a;
        window.open('https://ipfs.io/ipfs/' + ipfsAdd);
    };

    sendToIPFS = async (event) => {
        event.preventDefault();

        //Get the metamask account using Web3.
        const stuMMAccount = await web3.eth.getAccounts();

        console.log('Sending from Metamask account: ' + stuMMAccount[0]);

        //Call handleIPFSAddr.js to get the contract address and ABI.
        const ethAddress = await handleIPFSAddr.options.address;
        this.setState({ ethAddress });

        //save the file and return the IPFS reference address.
        await ipfs.add(this.state.buffer, (err, a) => {
            console.log(err, a);
            this.setState({ a: a[0].hash });
            handleIPFSAddr.methods.sendA(this.state.a).send({
                from: stuMMAccount[0]
            }, (error, transactionHash) => {
                this.setState({ transactionHash });
            });

        });

        await web3.eth.getTransactionReceipt(this.state.transactionHash, (err, txReceipt) => {
            console.log('txreceipt:', err, txReceipt);
            this.setState({ txReceipt });
        });

    };

    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <h1>Submit Assignment to IPFS</h1>
                </header>

                <hr />

                <Grid>
                    <h3> Choose file to send to IPFS </h3>
                    <Form onSubmit={this.sendToIPFS}>
                        <input type="file" onChange={this.selectAssignFile}/>
                        <Button type="submit">
                            Send it
                        </Button>
                    </Form>
                </Grid>
                    <hr />

                <Grid>
                    <Card>
                        <CardActionArea>
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="h2">
                                    Your Assignment IPFS File Address
                                    <br />
                                    {this.state.a}
                                    <br />
                                </Typography>
                                <Typography variant="body" color="textSecondary" component="p">
                                    Ethereum Contract Address
                                    <br />
                                    {this.state.ethAddress}
                                    <br />
                                    Ethscan Transaction Code
                                    <br />
                                    {this.state.transactionHash}
                                </Typography>
                            </CardContent>
                        </CardActionArea>
                        <CardActions>
                            <Button size="large" color="primary" onClick={this.viewOnRinkeby}>
                                Transaction Details
                            </Button>
                            <Button size="large" color="primary" onClick={this.dlFromIPFS}>
                                Download IPFS File
                            </Button>
                        </CardActions>
                    </Card>
                </Grid>

            </div>
        );
    }
}