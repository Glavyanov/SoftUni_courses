import { Footer } from './Footer';
import { Header } from './Header';
import { Search } from './Search';
import { UserList } from './UserList';

export const Home = ({
    users,
    onUserCreateSubmit,
    onUserDelete,
    onUserUpdateSubmit,
    formValues,
    formChangeHandler,
    formErrors,
    resetFormValues,
}) => {
    return (
        <>
            <Header />
            <main className="main">
                <section className="card users-container">
                    <Search />

                    <UserList
                        users={users}
                        onUserCreateSubmit={onUserCreateSubmit}
                        onUserDelete={onUserDelete}
                        onUserUpdateSubmit={onUserUpdateSubmit}
                        formValues={formValues}
                        formChangeHandler={formChangeHandler}
                        formErrors={formErrors}
                        resetFormValues={resetFormValues}
                    />
                </section>
            </main>
            <Footer />
        </>
    );
}