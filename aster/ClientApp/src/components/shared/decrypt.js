import React, { Component } from 'react';
import CryptoJS from "react-native-crypto-js";
import { Form } from 'react-bootstrap';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';

export class decrypt extends Component {

    state = {
        ipfsFileOutput: ''
    };

    captureFile = (event) => {
        event.stopPropagation()
        event.preventDefault()

        const file = event.target.files[0]
        let reader = new window.FileReader()
        reader.readAsBinaryString(file)
        reader.onloadend = () => this.decrypt(reader)
    };

    decrypt = (reader) => {
        const dataFile = (reader.result),
              decryptFile = CryptoJS.AES.decrypt(dataFile.toString(), "Secret"), // THIS IS NOT ADVISABLE, AS THE KEY IS VISIBLE VIA THE CLIENT!
              ipfsFileOutput = CryptoJS.enc.Utf8.stringify(decryptFile);
              //buffer = new Buffer(ipfsFileOutput); //Is this required if I want to output to a file??
        console.log('dataFile:', dataFile)
        console.log('decrypted:', decryptFile)
        //console.log('buffer:', buffer)
        this.setState({ ipfsFileOutput })

    };

    render() {
        return (
            <div>
                <header className="App-header">
                    <h1>Decrypt assignment from IPFS</h1>
                </header>
                <hr />
                <Grid>
                    <h3>Choose file to decrypt</h3>
                    <Form>
                        <input type="file" onChange={this.captureFile}/>
                        <Button type="submit">
                            Send it
                        </Button>
                    </Form>
                    <h4> {this.state.ipfsFileOutput} </h4>
                </Grid>
            </div>
        );
    }
}

