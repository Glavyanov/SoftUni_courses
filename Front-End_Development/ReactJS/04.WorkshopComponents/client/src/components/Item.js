import { formatDate } from './User';
import { Link } from 'react-router-dom';


export const Item = ({
    _id,
    itemName,
    imageUrl,
    description,
    createdAt,
    updatedAt,
}) => {
    return (
        <div className="overlay">
            <div className="backdrop"></div>
            <div className="modal">
                <div className="detail-container">
                    <div className="content">
                        <div className="image-container">
                            <img src={imageUrl} alt={itemName}
                                className="image" />
                        </div>
                        <div className="user-details">
                            <p>Item Id: <strong>{_id}</strong></p>
                            <p>
                                Item Name:
                                <strong> {itemName} </strong>
                            </p>
                            <p>Description: <strong>{description}</strong></p>

                            <p>Created on: <strong>{formatDate(createdAt)}</strong></p>
                            <p>Modified on: <strong>{formatDate(updatedAt)}</strong></p>
                            <Link to="/" ><button type='button' style={{cursor: "pointer", marginTop: "20px"}}>Back</button></Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}