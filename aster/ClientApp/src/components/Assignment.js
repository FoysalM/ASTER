import React, { Component } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Skeleton from '@material-ui/lab/Skeleton';

const style = {
fontSize: 14,
};

const loading = false 

export class Assignment extends Component {
    displayName = Assignment.name

    constructor(props) {
        super(props)
        this.state = {
            assignList: []
        }
    };

    componentDidMount() {
        this.getAssigns();
    }

    getAssigns() {
        this.stu = fetch('https://asteruniapi.azurewebsites.net/api/assignment')
            .then(response => response.json())
            .then(response => this.setState({ assignList: response }))
            .catch(err => console.error(err))
    }

    renderAssignList = ({ assignId, modId, assignName }) =>
        <TableRow key={assignId}>
            {loading ? (
                <React.Fragment>
                    <Skeleton variant='text'/>
                </React.Fragment>
            ) : (<TableCell style={style}>{assignId}</TableCell>)} 
            {loading ? (
                <React.Fragment>
                    <Skeleton variant='text'/>
                </React.Fragment>
            ) : (<TableCell style={style}>{modId}</TableCell>)}
            <TableCell style={style}>{assignName}</TableCell>
            <TableCell style={style}></TableCell>
            <TableCell style={style}></TableCell>
        </TableRow>

    render() {
        const { assignList } = this.state;

        return (
            <div className="test">
                <h1>Assignment List</h1>
                <hr />
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell style={style}>Assignment ID</TableCell>
                            <TableCell style={style}>Module ID</TableCell>
                            <TableCell style={style}>Assignment Title</TableCell>
                            <TableCell style={style}>Start Date</TableCell>
                            <TableCell style={style}>End Date</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {assignList.map(this.renderAssignList) }
                    </TableBody>
                    </Table>
            </div>
        );
    }
}