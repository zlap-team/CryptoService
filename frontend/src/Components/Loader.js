import React from 'react'
import { Spinner } from 'react-bootstrap'

export default function Loader() {
  return (
    <div>
        <Spinner 
            animation='border'
            role='status'
            style={{
                height: '100px',
                width: '100px',
                margin: 'auto',
                display: 'block'
            }}
        >
            <span className='sr-only'>Ładuję...</span>
        </Spinner>
    </div>
  )
}
