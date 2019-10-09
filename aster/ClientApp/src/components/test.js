import { Table, Grid } from 'react-bootstrap';
import React, { Component } from 'react';

export class test extends Component {
    displayName = test.name

    constructor(props) {
        super(props)
        this.state = {
            studentList: []
        }
    };

    componentDidMount() {
        this.getStudents();
    }

    getStudents() {
        this.stu = fetch('https://localhost:44332/api/student')
            .then(response => response.json())
            .then(response => this.setState({ studentList: response }))
            .catch(err => console.error(err))
    }
    renderStudentList = ({ stuID, title, fName, sName, email }) =>
        <tr key={stuID}>
            <td>{stuID}</td>
            <td>{title}</td>
            <td>{fName}</td>
            <td>{sName}</td>
            <td>{email}</td>
        </tr>

    render() {
        const { studentList } = this.state;
        return (
            <div className="test">
                <h1>Student List</h1>
                <hr />
                <Grid>
                    <Table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Title</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Email</th>
                            </tr>
                        </thead>
                        <tbody>
                            {studentList.map(this.renderStudentList)}
                        </tbody>
                    </Table>
                </Grid>
            </div>
        );
    }
}