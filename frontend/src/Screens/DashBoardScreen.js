import React, {useState, useEffect} from 'react'
import axios from 'axios'
import { Table } from 'react-bootstrap'
export default function DashBoardScreen() {

  const [coins, setCoins] = useState()

  useEffect(() =>{
      async function fetchNews(){
          const {data} = await axios.get('https://127.0.0.1:5001/api/CoinApi')
          setCoins(data)
      }
      fetchNews()
  }, [])

  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nazwa</th>
            <th>Symbol</th>
            <th>Last Name</th>
            <th>Username</th>
          </tr>
        </thead>

        <tbody>
        {coins?.map((item) =>{
          return(
            <tr>
              <td>{item.exchangeId}</td>
              <td>Mark</td>
              <td>Otto</td>
              <td>@mdo</td>
            </tr>
          )
        })}
          <tr>
            <td>2</td>
            <td>Jacob</td>
            <td>Thornton</td>
            <td>@fat</td>
          </tr>
          <tr>
            <td>3</td>
            <td colSpan={2}>Larry the Bird</td>
            <td>@twitter</td>
          </tr>
        </tbody>
      </Table>
    </div>
  )
}
