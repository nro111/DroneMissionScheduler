import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import axios from 'axios';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

export class Drones extends Component {
    static displayName = Drones.name;

    constructor(props) {
        super(props);
        this.state = { result: [], loading: true, createModal: false, editModal: false, nickname: "", make: "", model: "", serialNumber: 0, yearManufactured: 0 };
        this.toggleCreateModal = this.toggleCreateModal.bind(this);
        this.toggleEditModal = this.toggleEditModal.bind(this);
    }

    componentDidMount() {
        this.populateDroneData();
    }

    toggleCreateModal() {
        this.setState({
            createModal: !this.state.createModal
        });
    }

    toggleEditModal() {
        this.setState({
            editModal: !this.state.editModal            
        });
    }

    ChangeNickname(value) {
        this.setState({
            nickname: value
        });
    }

    ChangeMake(value) {
        this.setState({
            make: value
        });
    }

    ChangeModel(value) {
        this.setState({
            model: value
        });
    }

    ChangeSerialNumber(value) {
        this.setState({
            serialNumber: value
        });
    }

    ChangeYearManufactured(value) {
        this.setState({
            yearManufactured: value
        });
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel">Drones</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Nickname</th>
                            <th>Make</th>
                            <th>Model</th>
                            <th>Serial Number</th>
                            <th>Year Manufactured</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.result.map(drone =>
                            <tr key={drone._id} id={drone._id}>
                                <td>{drone.Nickname}</td>
                                <td>{drone.Make}</td>
                                <td>{drone.Model}</td>
                                <td>{drone.SerialNumber}</td>
                                <td>{drone.YearManufactured}</td>
                                <td><Button onClick={this.toggleEditModal} color="warning"><FontAwesomeIcon icon={faEdit} /></Button> <Button color="danger"><FontAwesomeIcon icon={faTrash} /></Button></td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <Button color='success' onClick={this.toggleCreateModal}>Create New Drone</Button>

                <Modal isOpen={this.state.createModal} toggle={this.toggleCreateModal} className={this.props.className}>
                    <ModalHeader toggle={this.toggleCreateModal}>New Drone Information</ModalHeader>
                    <ModalBody>
                        <Form>
                            <FormGroup>
                                <Label for="txtDroneNickname">Nickname</Label>
                                <Input type="text" name="nickname" id="txtDroneNickname" onChange={(e) => this.ChangeNickname(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtDroneMake">Make</Label>
                                <Input type="text" name="make" id="txtDroneMake" onChange={(e) => this.ChangeMake(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtDroneModel">Model</Label>
                                <Input type="text" name="make" id="txtDroneModel" onChange={(e) => this.ChangeModel(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtSerialNumber">Serial Number</Label>
                                <Input type="number" name="serialNumber" id="txtSerialNumber" onChange={(e) => this.ChangeSerialNumber(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtYearManufactured">Year Manufactured</Label>
                                <Input type="number" name="yearManufactured" id="txtYearManufactured" onChange={(e) => this.ChangeYearManufactured(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                        </Form>
                    </ModalBody>
                    <ModalFooter>
                        <Button color='danger' onClick={this.toggleCreateModal}>Cancel</Button>
                        <Button color='success' onClick={this.createNewDrone.bind(this)}>Create</Button>{' '}
                    </ModalFooter>
                </Modal>
                <Modal isOpen={this.state.editModal} toggle={this.toggleEditModal} className={this.props.className}>
                    <ModalHeader toggle={this.toggleEditModal}>Edit Drone Information</ModalHeader>
                    <ModalBody>
                        <Form>
                            <FormGroup>
                                <Label for="txtDroneNickname">Nickname</Label>
                                <Input type="text" name="nickname" id="txtDroneNickname" onChange={(e) => this.ChangeNickname(`${e.target.value}`)} placeholder={this.Nickname } />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtDroneMake">Make</Label>
                                <Input type="text" name="make" id="txtDroneMake" onChange={(e) => this.ChangeMake(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtDroneModel">Model</Label>
                                <Input type="text" name="make" id="txtDroneModel" onChange={(e) => this.ChangeModel(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtSerialNumber">Serial Number</Label>
                                <Input type="number" name="serialNumber" id="txtSerialNumber" onChange={(e) => this.ChangeSerialNumber(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="txtYearManufactured">Year Manufactured</Label>
                                <Input type="number" name="yearManufactured" id="txtYearManufactured" onChange={(e) => this.ChangeYearManufactured(`${e.target.value}`)} placeholder="" />
                            </FormGroup>
                        </Form>
                    </ModalBody>
                    <ModalFooter>
                        <Button color='danger' onClick={this.toggleEditModal}>Cancel</Button>
                        <Button color='success' onClick={this.editExistingDrone.bind(this)}>Save Changes</Button>{' '}
                    </ModalFooter>
                </Modal>
            </div>
        );
    }

    async populateDroneData() {
        const url = `https://localhost:44316/api/Drone/getAll`;
        axios
            .get(url)
            .then(response => {
                this.setState({ result: response.data, loading: false });
            })
            .catch(error => {
                this.setState({ error: 'Failed to generate result, please try again' });
            })
    }

    createNewDrone() {
        const json = JSON.stringify({
            Nickname: this.state.nickname,
            Make: this.state.make,
            Model: this.state.model,
            SerialNumber: this.state.serialNumber,
            YearManufactured: this.state.yearManufactured
        });
        const url = `https://localhost:44316/api/Drone/add/` + json;
        axios
            .post(url)
            .then(response => {
                this.populateDroneData();
                this.toggle();
            })
            .catch(error => {
                this.setState({ error: 'Failed to generate result, please try again' });
            })
    }

    editExistingDrone() {
        const json = JSON.stringify({
            _id: this.state._id,
            Nickname: this.state.nickname,
            Make: this.state.make,
            Model: this.state.model,
            SerialNumber: this.state.serialNumber,
            YearManufactured: this.state.yearManufactured
        });
        const url = `https://localhost:44316/api/Drone/update/` + this.state._id + `/as/` + json;
        axios
            .put(url)
            .then(response => {
                this.populateDroneData();
                this.toggle();
            })
            .catch(error => {
                this.setState({ error: 'Failed to generate result, please try again' });
            })
    }
}
