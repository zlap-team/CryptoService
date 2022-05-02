import React, {useEffect} from 'react'
import { useDispatch } from 'react-redux'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { getSingleCrypto } from '../actions/cryptoActions'
import { Card, Button } from 'react-bootstrap'
import {Tab, Tabs} from 'react-bootstrap'
import {Table} from 'react-bootstrap'

export default function SingleCryproScreen() {

    const { id } = useParams()
    const dispatch = useDispatch()

    const getSingleCrypro = useSelector(state => state.getSingleCrypro)
    const {loading, error, singleCrypto} = getSingleCrypro

    useEffect(() =>{
        dispatch(getSingleCrypto(id))
        console.log(singleCrypto)
    }, [dispatch, id])

  return (
    <div>
        {/* <div style={{ width: '72rem', height: '72rem' }}>
            <Card.Img style={{ width: '8rem', height: '8rem' }} variant="top" src={singleCrypto["image"] && singleCrypto["image"].large} />
            <Card.Body>
                <Card.Title>{singleCrypto && singleCrypto.name}</Card.Title>
                <Card.Text>
                    Symbol: {singleCrypto && singleCrypto.symbol}
                </Card.Text>
                <Card.Text>
                    Genesis date: { singleCrypto.genesis_date ? singleCrypto.genesis_date : "No Information from API"}
                </Card.Text>
                <Card.Text>
                    Hashing Algoritm: {singleCrypto.hashing_algorithm ? singleCrypto.hashing_algorithm : "No Information from API"}
                </Card.Text>
                <Card.Text>
                    Description: {singleCrypto.description && singleCrypto.description["en"]}
                </Card.Text>
            </Card.Body>
        </div> */}
        <div>
            <Card.Img style={{ width: '8rem', height: '8rem', float: 'left'}} variant="top" src={singleCrypto["image"] && singleCrypto["image"].large} />
            <h2 className='float-left'>{singleCrypto && singleCrypto.name}</h2>
        </div>
       <Tabs defaultActiveKey="valueChanges" id="uncontrolled-tab-example" className="mb-3">
            <Tab eventKey="name" title={singleCrypto && singleCrypto.name} disabled></Tab>
            <Tab eventKey="basicinfo" title="Basic information">
                <h4>Name: {singleCrypto && singleCrypto.name}<br/></h4>
                <h4>Genesis date: { singleCrypto.genesis_date ? singleCrypto.genesis_date : "No Information from API"}<br/></h4>
                <h4>Hashing Algoritm: {singleCrypto.hashing_algorithm ? singleCrypto.hashing_algorithm : "No Information from API"}<br/></h4>
            </Tab>
            <Tab eventKey="descritpion" title="Description" >
                <h2>Description:</h2><br/> <h4>{singleCrypto.description && singleCrypto.description["en"]}</h4>
            </Tab>
            <Tab eventKey="valueChanges" title="Value Changes" >
                <Table striped bordered hover variant="light">
                    <thead>
                        <tr>
                            <th>Current Price</th>
                            <th>High 24h</th>
                            <th>Low 24h</th>
                            <th>Price Change 1h</th>
                            <th>Price Change 24h</th>
                            <th>Price Change 7d</th>
                            <th>Price Change 14d</th>
                            <th>Price Change 30d</th>
                            <th>Price Change 60d</th>
                            <th>Price Change 200d</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].current_price.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].current_price.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].current_price.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].high_24h.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].high_24h.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].high_24h.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].low_24h.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].low_24h.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].low_24h.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_1h_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_1h_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_1h_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_24h_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_24h_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_24h_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_7d_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_7d_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_7d_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_14d_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_14d_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_14d_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_30d_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_30d_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_30d_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_60d_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_60d_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_60d_in_currency.eur}</h7>)}</td>
                            <td>{singleCrypto["market_data"] && (singleCrypto["market_data"].price_change_percentage_200d_in_currency.eur > 0 ? <h7 className="text-success">{singleCrypto["market_data"].price_change_percentage_200d_in_currency.eur}</h7> : <h7 className="text-danger">{singleCrypto["market_data"].price_change_percentage_200d_in_currency.eur}</h7>)}</td>
                        </tr>
                    </tbody>
                </Table>
            </Tab>
        </Tabs>
    </div>
  )
}
