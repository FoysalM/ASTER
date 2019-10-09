import React, { Component } from 'react';
import CryptoJS from "react-native-crypto-js";
//import fs from 'fs';
import { Form } from 'react-bootstrap';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';

export class decrypt extends Component {

    captureFile = (event) => {
        event.stopPropagation()
        event.preventDefault()
        const file = event.target.files[0]
        let reader = new window.FileReader()
        console.log('reader:', reader);
        reader.readAsArrayBuffer(file)
        reader.onloadend = () => this.decrypt(reader)
    };

    decrypt = (reader) => {
        const dataFile = (reader.result);
        console.log('data file:', dataFile)
        const decryptFile = CryptoJS.AES.decrypt(dataFile.toString('base64'), "Secret");
        console.log('decrypted:', decryptFile)
        const result = CryptoJS.enc.Utf8.stringify(decryptFile);
        console.log('result:', result)
        const buffer = new Buffer(result, 'base64');
        console.log('buffer:', buffer)
        //fs.writeFileSync(reader, buffer);
    }

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
                </Grid>
            </div>
        );
    }
}

