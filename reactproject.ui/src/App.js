import React, { useState , useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
import {Modal,ModalBody,ModalFooter,ModalHeader} from 'reactstrap'

function App() { 
  const baseUrl="https://localhost:7262/api/Equipo";
  const [data,setData]=useState([]);

  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
      console.log(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    peticionGet();
  },[])

  return (
    <div className="App">
      
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Código</th>
            <th>Descripción</th>
            <th>Modelo</th>
            <th>Serial</th>
            <th>Tipo</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
            {data.map(equipo=>(
                <tr key={equipo.idEquipo}>
                  <td>{equipo.codigoEquipo}</td>
                  <td>{equipo.descripcionEquipo}</td>
                  <td>{equipo.modelo}</td>
                  <td>{equipo.serial}</td>
                  <td>{equipo.idEquipoTipo}</td>
                  <td>
                    <button className='btn btn-primary'>Editar</button> {" "}
                    <button className='btn btn-danger'>Eliminar</button>
                  </td>
                </tr>

            ))}
        </tbody>
      </table>

    </div>
  );
}

export default App;
