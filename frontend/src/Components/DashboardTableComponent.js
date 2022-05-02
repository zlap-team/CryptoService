import React from 'react'
import Image from 'react-bootstrap/Image'
import { LinkContainer } from 'react-router-bootstrap'

export default function DashboardTableComponent({coinsData}) {

    const myDate = new Date(coinsData.lastUpdated)
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
        }else if (days <= 0 && minutes >= 60){
            return hours + " hours ago"
        }else if(hours < 1 && sec >= 60){
            return minutes + " minutes ago"
        }else{
            return sec + " seconds ago"
        }
    }

  return (
        <tr>
            <td>
                <LinkContainer to={`/crypto/${coinsData.id}`}>
                    <Image src={coinsData.image} width={'40vw'}></Image>
                </LinkContainer>
            </td>
            <td>
                <LinkContainer to={`/crypto/${coinsData.id}`}>
                    <h5 className='text-secondary'>{coinsData.name}</h5>
                </LinkContainer>
            </td>
            <td>
                <LinkContainer to={`/crypto/${coinsData.id}`}>
                    <h5>{coinsData.currentPrice}</h5>
                </LinkContainer>
            </td>
            {coinsData.priceChange24h>0
                ? <td>
                    <LinkContainer to={`/crypto/${coinsData.id}`}>
                        <h5 className='text-success'>
                            {coinsData.priceChange24h}
                        </h5>
                    </LinkContainer >
                </td>
                : <td>
                    <LinkContainer to={`/crypto/${coinsData.id}`}>
                        <h5 className='text-danger'>
                            {coinsData.priceChange24h}
                        </h5>
                    </LinkContainer>
                </td>}
            <td>
                <LinkContainer to={`/crypto/${coinsData.id}`}>
                    <h6>{dhm(timeDifference)}</h6>
                </LinkContainer>
            </td>
        </tr>
  )
}
