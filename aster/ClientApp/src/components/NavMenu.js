import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fluid collapseOnSelect>
        <Navbar.Header>
                <LinkContainer to={'/'}>
                <Navbar.Brand>
            <Link to={'/'}>ASTER (Prototype)</Link>
                    </Navbar.Brand>
                </LinkContainer>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Dashboard
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/assignment'}>
              <NavItem>
                <Glyphicon glyph='education' /> Assignment List
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchdata'}>
              <NavItem>
                <Glyphicon glyph='duplicate' /> Fetch data
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/student/submittoipfs'}>
              <NavItem>
                 <Glyphicon glyph='send' /> Submit To IPFS
              </NavItem>
             </LinkContainer>
             <LinkContainer to={'/test'}>
              <NavItem>
                 <Glyphicon glyph='send' /> Test
              </NavItem>
             </LinkContainer>
             <LinkContainer to={'/shared/decrypt'}>
              <NavItem>
                 <Glyphicon glyph='export' /> Decrypt
              </NavItem>
             </LinkContainer>
             <LinkContainer to={'/login'}>
              <NavItem>
                  <Glyphicon glyph='log-in' /> Login
              </NavItem>
             </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
