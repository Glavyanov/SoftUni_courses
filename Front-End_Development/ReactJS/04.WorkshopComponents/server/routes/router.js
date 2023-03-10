const userRouter = require('./user.js');
const itemRouter = require('./item.js');

module.exports = (app) => {
  app.use('/api/users', userRouter);
  app.use('/api/items', itemRouter);
};
