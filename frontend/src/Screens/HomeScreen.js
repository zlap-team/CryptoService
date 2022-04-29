import React, {useState, useEffect} from 'react'
import axios from 'axios'
import { Table } from 'react-bootstrap'
import Image from 'react-bootstrap/Image'
import DashboardTableComponent from '../Components/DashboardTableComponent'
import { useDispatch } from 'react-redux'
import Message from '../Components/Message'
import Loader from '../Components/Loader'
import { useSelector } from 'react-redux'
import { listCrypto } from '../actions/cryptoActions'

export default function DashBoardScreen() {

  const dispatch = useDispatch()
  const cryptoList = useSelector(state => state.cryptoList)
  const {error, loading, products} = cryptoList


    useEffect(() =>{
        dispatch(listCrypto())

    }, [dispatch])

    const renderItems = products.slice(0,10).map((item)=>{
        return(
            <DashboardTableComponent coinsData={item} />
        )
    })

    const renderItemsToTheEnd = products.slice(11).map((item)=>{
        return(
            <DashboardTableComponent coinsData={item} />
        )
    })


  return (
    <div>
        <h1>Most popular crypto right now!</h1>
        <h6>You can check details of every crypto in our Dashboard</h6>
        {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
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
                    {renderItems}
                    </tbody>
                </Table>
                <h1>... and the rest of them</h1>
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
                    {renderItemsToTheEnd}
                    </tbody>
                </Table>
            </div>
        }
    </div>
  )
}
