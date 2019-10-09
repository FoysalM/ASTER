import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

export class test extends Component {
    displayName = test.name

    componentDidMount() {
        this.getStudents();
    }


    state = {
        students: [], loading: true
    }

    getStudents() {
        this.arb = fetch('https://uni01.azurewebsites.net/api/StudentList')
            .then(response => response.json())
            .then(response => this.setState({ students: response.data }));
    }


    renderStudent = ({ stuID, fName, sName }) => <div key={stuID}>{fName}, {sName}</div>

    render() {
        const { students } = this.state;
        return (
            <div className="test">
                <Grid fluid>
                    <Row>
                        <Col sm={9}>
                            {students.map(this.renderStudent)}
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}