import { Navigation, NavLinkItem } from './Navigation';
import styles from './Navigation.module.css';

export const MainNavigation = () => {
    return (
        <Navigation>
            <NavLinkItem className={({isActive}) => isActive ? styles['nav-active'] : styles['nav-non-active']} to="/">Home</NavLinkItem>
            <NavLinkItem className={({isActive}) => isActive ? styles['nav-active'] : styles['nav-non-active']} to="/about">About</NavLinkItem>
            <NavLinkItem className={({isActive}) => isActive ? styles['nav-active'] : styles['nav-non-active']} to="/characters">Characters</NavLinkItem>
        </Navigation>
    );
};