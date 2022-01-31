import React, { useState , useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
import {Modal,ModalBody,ModalFooter,ModalHeader} from 'reactstrap'
import { paste } from '@testing-library/user-event/dist/paste';

function App() { 
  const baseUrl="https://localhost:7262/Api/Vehiculo";
  const [data,setData]=useState([]);
  const [modalEditar,setModalEditar]=useState(false)
  const [modalInsertar,setModalInsertar]=useState(false)
  const [modalEliminar,setModalEliminar]=useState(false) 
  const [vehiculoSeleccionado, setVehiculoSeleccionado]=useState({
    idVehiculo: 0,
    placa: 0,
    descripcion: ''

  })

  const handleChange=e=>{
    const {name,value}=e.target;
    setVehiculoSeleccionado({
      ...vehiculoSeleccionado,
      [name]:value
    });
    console.log(vehiculoSeleccionado);
  }

  const abrircerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
  }

  const abrircerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrircerrarModalEliminar=()=>{
    setModalEliminar(!modalEliminar);
  } 

  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
      console.log(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPost=async()=>{
    delete vehiculoSeleccionado.idVehiculo;
    console.log(vehiculoSeleccionado)
    await axios.post(baseUrl,vehiculoSeleccionado)
    .then(response=>{
      setData(data.concat(response.data));
      console.log(response.data);
      abrircerrarModalInsertar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPut=async()=>{
    await axios.post(baseUrl,vehiculoSeleccionado)
    .then(response=>{
      var respuesta=response.data;
      var dataAuxiliar= data;
      dataAuxiliar.map(vehiculo=>{
        if(vehiculo.idVehiculo===vehiculoSeleccionado.idVehiculo)
        {
          vehiculo.descripcion = respuesta.descripcion;
          vehiculo.placa = respuesta.placa;
        }
      })
      abrircerrarModalEditar();
    }).catch(error=>{
      console.log("QUE A PASADO AHORA!")
      console.log(error);
    })
  } 

  const peticionDelete=async()=>{
    await axios.delete(baseUrl+"/"+vehiculoSeleccionado.idVehiculo)
    .then(response=>{
      setData(data.filter(vehiculo=>vehiculo.idVehiculo !== response.data))
      abrircerrarModalEliminar();
    }).catch(error=>{
      console.log("QUE A PASADO AHORA!")
      console.log(error);
    })
  }

  
  const seleccionarVehiculo=(vehiculo,caso)=>{
    setVehiculoSeleccionado(vehiculo);
    (caso==="Editar")?
    abrircerrarModalEditar(): abrircerrarModalEliminar();
  }


  useEffect(()=>{
    peticionGet();
  },[])

  return (
    <div className="App">
      <br></br>
      <button onClick={()=>abrircerrarModalInsertar()} className='btn btn-success'>Insertar nuevo equipo</button>
      <br></br>
      <br></br>
      <table className='table table-bordered'>
        <thead>
          <tr>
          <th>Id</th>
            <th>Placa</th>
            <th>Descripción</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
            {data.map(vehiculo=>(
                <tr key={vehiculo.idVehiculo}>
                  <td>{vehiculo.idVehiculo}</td>
                  <td>{vehiculo.placa}</td>
                  <td>{vehiculo.descripcion}</td>
                  <td>
                    <button className='btn btn-primary' onClick={()=>seleccionarVehiculo(vehiculo,"Editar")}>Editar</button> {" "}
                    <button className='btn btn-danger' onClick={()=>seleccionarVehiculo(vehiculo,"Eliminar")}>Eliminar</button>
                  </td>
                </tr>

            ))}
        </tbody>
      </table>

      <Modal isOpen={modalInsertar}>
        <ModalHeader>Insertar vehiculo en base de datos</ModalHeader>
        <ModalBody>
          <labe>Placa</labe>
          <br/>
          <input type="text" className="form-control" name="placa" onChange={handleChange}/>
          <br/>
          <label>Descripción</label>
          <input type="text" className="form-control" name="descripcion" onChange={handleChange}/>
                                    
        </ModalBody>
        <ModalFooter>
        <button className='btn btn-primary' onClick={()=>peticionPost()}>Insertar</button>
        <button className='btn btn-danger' onClick={()=>abrircerrarModalInsertar()}>Cancelar</button>
      </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar vehiculo en base de datos</ModalHeader>
        <ModalBody>
        <labe>Placa</labe>
          <br/>
          <input type="text" className="form-control" readOnly name='idVehiculo' value={vehiculoSeleccionado && vehiculoSeleccionado.idVehiculo}/>
          <br/>
          <labe>Placa</labe>
          <br/>
          <input type="text" className="form-control" name='placa' value={vehiculoSeleccionado && vehiculoSeleccionado.placa} onChange={handleChange}/>
          <br/>
          <label>Descripción</label>
          <input type="text" className="form-control" name='descripcion' value={vehiculoSeleccionado && vehiculoSeleccionado.descripcion} onChange={handleChange}/>
                                    
        </ModalBody>
        <ModalFooter>
        <button className='btn btn-primary' onClick={()=>peticionPut()}>Editar</button>
        <button className='btn btn-danger' onClick={()=>abrircerrarModalEditar()}>Cancelar</button>
      </ModalFooter>

      </Modal>

      <Modal isOpen={modalEliminar}>
        <ModalBody>
          ¿Esta seguro de que desea eliminar el registro seleccionado? {vehiculoSeleccionado.placa}
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-danger' onClick={()=>peticionDelete()}>SI</button>
          <button className='btn btn-secondary' onClick={()=>abrircerrarModalEliminar()}>NO</button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default App;
