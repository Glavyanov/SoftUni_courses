import { Link, NavLink } from 'react-router-dom';
import styles from './Navigation.module.css';

export const Navigation = ({
    children,
}) => {
    return (
        <nav className={styles.navigation}>
            <ul>
                {children}
            </ul>
        </nav>
    );
};

export const NavItem = ({
    to,
    children,
}) => {
    return <li><Link to={to}>{children}</Link></li>
};

export const NavLinkItem = ({
    to,
    className,
    children,
}) => {
    return <li><NavLink className={className} to={to}>{children}</NavLink></li>
};