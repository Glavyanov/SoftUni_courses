const router = require('express').Router();
const controller = require('../controllers/item');

router.get('', controller.getItems);
router.get('/:itemId', controller.getItem);

router.post('', controller.addItem);

module.exports = router;
