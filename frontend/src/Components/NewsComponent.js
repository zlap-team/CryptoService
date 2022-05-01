import React, { useEffect } from 'react'
import axios from 'axios';
import { useState } from 'react';
import { Card, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import '../stylesheets/NewsStylesheet.css'

export default function NewsComponent({news}) {
    
    const myDate = new Date(news.publishedAt)
    const timeNow = Date.now()
    Date.parse(myDate)
    const timeDifference = timeNow - myDate

    function dhm (ms) {
        const days = Math.floor(ms / (24*60*60*1000));
        const daysms = ms % (24*60*60*1000);
        const hours = Math.floor(daysms / (60*60*1000));
        const hoursms = ms % (60*60*1000);
        const minutes = Math.floor(hoursms / (60*1000));
        const minutesms = ms % (60*1000);
        const sec = Math.floor(minutesms / 1000);

        if (days > 0){
            return days + " days ago"
        }else if (days <= 0 && hours < 1){
            return minutes + " minutes ago"
        }else{
            return hours + " hours " + minutes + " minutes ago" 
        }
    }

    const redirectUser = (par) =>{
        window.open(par, '_blank');
    }
    

    return (
        <Card style={{ width: '40rem', height: '35rem'}} className='my-3  rounded'>
            <Card.Body>
                {/* <Link to={news.url}>
                    <Card.Img className='mb-3'src={news.urlToImage}/>
                </Link> */}
                <Button variant="light" onClick={() => {redirectUser(news.url)}}>
                    <Card.Img className='mb-3'src={news.urlToImage}/>
                </Button>
                <Link to={`/product/`} style={{textDecoration: 'none'}}>
                    <Card.Title as="div"><strong>{news.title}</strong></Card.Title>
                </Link>
                <Card.Text>
                    {news.description} 
                </Card.Text>
                <Card.Text>
                    Created: {dhm(timeDifference)}
                </Card.Text>
            </Card.Body>
        </Card>
  )
}
