using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    enum BlockType
    {
        /// <summary>
        /// *
        /// *
        /// *
        /// *
        /// </summary>
        I_Block, 
        /// <summary>
        ///  *  
        ///  *  
        /// **  
        /// </summary>
        J_Block,  
        /// <summary>
        /// *
        /// *
        /// **
        /// </summary>
        L_Block,
        /// <summary>
        /// **
        /// **
        /// </summary>
        O_Block, 
        /// <summary>
        ///  **
        /// **
        /// </summary>
        S_Block,
        /// <summary>
        /// ***
        ///  *
        /// </summary>
        T_Block,
        /// <summary>
        /// **
        ///  **
        /// </summary>
        Z_Block
    }    

    class BlockTypeRandomizer
    {
        public static BlockType GetBlockType()
        {
            Array values = Enum.GetValues(typeof(BlockType));
            Random random = new Random();

            return (BlockType)values.GetValue(random.Next(values.Length));
        }
    }
}
