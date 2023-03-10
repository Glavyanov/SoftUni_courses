const { itemModel } = require('../models/Item');
const { errorHandler } = require('../utils/errorHandler');
const { ValidationError } = require('../utils/createValidationError');

const getItem = async (req, res) => {
    const { itemId } = req.params;

    try {
        const item = await itemModel.findById(itemId, '-__v -isDeleted');

        if (!item) {
            throw new ValidationError('There is no such item with provided id.', 404);
        }

        res.status(200).json({ item: item.toObject() });
    } catch (error) {
        errorHandler(error, res, req);
    }
};

const addItem = async (req, res) => {
    const { itemName, imageUrl, description } = req.body;
    const data = { itemName, imageUrl, description};

    try {
        const createdItem = await itemModel.create({ ...data });
        const item = { ...data, _id: createdItem._id, createdAt: createdItem.createdAt, updatedAt: createdItem.updatedAt };

        res.status(200).json({ item });
    } catch (error) {
        errorHandler(error, res, req);
    }
};

const getItems = async (req, res) => {
    const page = parseInt(req?.query?.page) || 1;
    const limit = parseInt(req?.query?.limit) || 5;
    const sort = req?.query?.sort;
    const order = req?.query?.order;
    const search = req?.query?.search;
    const criteria = (req?.query?.criteria || '').trim();
    const skipIndex = (page - 1) * limit;
  
    const query = { isDeleted: false };
    const sortCriteria = {};
  
    if (sort && sort !== 'null' && order && order !== 'null') {
      sortCriteria[sort] = order;
    }
  
    if (search && search !== 'null' && criteria && criteria !== 'null') {
      query[criteria] = criteria == '_id' ? search : new RegExp(search, 'i');
    }
  
    try {
      const count = await itemModel.countDocuments(query);
      let items = await itemModel
        .find(query)
        .select('itemName imageUrl description createdAt updatedAt')
        .limit(limit)
        .skip(skipIndex)
        .sort(sortCriteria)
        .lean();
  
      res.status(200).json({ items, count });
    } catch (error) {
      if (error.kind === 'ObjectId') {
        return res.status(200).json({ items: [], count: 0 });
      }
  
      errorHandler(error, res, req);
    }
  };

module.exports = {
    getItem,
    addItem,
    getItems
};