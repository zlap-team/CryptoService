import React, {useState, useEffect} from 'react'
import axios from 'axios'
import { Table } from 'react-bootstrap'
import Image from 'react-bootstrap/Image'
import DashboardTableComponent from '../Components/DashboardTableComponent'

export default function DashBoardScreen() {

  const [coins, setCoins] = useState()

  useEffect(() =>{
      async function fetchNews(){
          const {data} = await axios.get('https://127.0.0.1:5001/api/CoinGeckoApi/markets/dot')
          setCoins(data)
      }
      fetchNews()
  }, [])


  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Symbol</th>
            <th>Name</th>
            <th>Current Price</th>
            <th>Price Change 24h</th>
            <th>Last Updated</th>
          </tr>
        </thead>
        <tbody>
          {coins?.map((item) => {
              return(
                <DashboardTableComponent coinsData={item} key={item.id}/>
              ) 
          })}
        </tbody>
        
        
      </Table>
    </div>
  )
}
