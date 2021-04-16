using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    enum PositionResult
    {
        SUCCESS, 
        DOWN_BORDER_STRIKE, 
        BORDER_STRIKE, 
        HEAP_STRIKE,
        NEW_BLOCK_IS_STUCKED
    }
}
