import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles({
    card: {
        maxWidth: 345,
        backgroundColor: 'black',
    },
});

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props)
        this.state = {
            moduleList: []
        }
    };

    componentDidMount() {
        this.getStudents();
    }

    getStudents() {
        this.stu = fetch('https://asteruniapi.azurewebsites.net/api/module')
            .then(response => response.json())
            .then(response => this.setState({ moduleList: response }))
            .catch(err => console.error(err))
    }

    renderModuleList = ({ modID, coursID, modName }) =>
        <Grid item sm={3} xs={6}>
            <Card className={useStyles.card} key={modID}>
                <CardActionArea>
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">
                            Module Name
                            <br />
                            {modName}
                        </Typography>
                        <Typography variant="body" color="textSecondary" component="p">
                            Module Description
                            <br />
                            Module belongs to Course: {coursID}
                        </Typography>
                    </CardContent>
                </CardActionArea>
                <CardActions>
                    <Button size="large" color="primary">
                        Open Module
                    </Button>
                </CardActions>
            </Card>
        </Grid>
        render() {
        const { moduleList } = this.state;
        return (
            <div>
                <h1>ASTER Dashboard</h1>
                <hr />
                <Grid container spacing={3}>
                    {moduleList.map(this.renderModuleList)}
                </Grid>
            </div>
        );
    }
}
