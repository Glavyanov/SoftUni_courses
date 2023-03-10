const { Schema, model } = require('mongoose');

const userSchema = new Schema(
    {
      itemName: {
        type: String,
        required: true,
        minLength: [2, 'Item name should be at least 2 characters long!'],
      },
      imageUrl: {
        type: String,
        required: true,
        match: [/^https?:\/\/.+/, 'ImageUrl is not valid!'],
      },
      description: {
        type: String,
        required: true,
        minLength: [5, 'Item description should be at least 5 characters long!'],

      },
      isDeleted: {
        type: Boolean,
        default: false,
      },
    },
    { timestamps: true }
  );

  const itemModel = model('Item', userSchema);
  module.exports = {
    itemModel,
  };