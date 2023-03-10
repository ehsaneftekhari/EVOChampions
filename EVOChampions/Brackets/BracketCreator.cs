namespace EVOChampions.Brackets
{
    internal class BracketCreator
    {
        private Node[] Nodes;
        int lastIndex;
        int NumberOFReounds;

        public BracketCreator(int UsersCount)
        {
            var numbers = CalculateNumbers(UsersCount);
            NumberOFReounds = numbers.NumberOFReounds;
            Nodes = new Node[numbers.NuberOfBlocks + 1];
            lastIndex = -1;
        }

        public void Create(out Node[] Nodes, out Node winnersFinalsNode, out Node? losersFinalsNode)
        {
            CreateBackward(out winnersFinalsNode, NumberOFReounds);
            Nodes = this.Nodes;
            losersFinalsNode = new Node(winnersFinalsNode.UpNode!, winnersFinalsNode.DownNode!, true, true);
            AddToNodes(losersFinalsNode);
        }

        private void CreateBackward(out Node node, int roundNumber)
        {
            node = null;
            if (roundNumber > 0)
            {
                node = new Node();
                AddToNodes(node);

                Node? newUpBlock = null;
                CreateBackward(out newUpBlock, roundNumber - 1);

                Node? newDownBlock = null;
                CreateBackward(out newDownBlock, roundNumber - 1);

                if (newUpBlock != null && newDownBlock != null)
                {
                    node.SetUpBlock(newUpBlock);
                    node.SetDownBlock(newDownBlock);
                }
            }
        }

        private void AddToNodes(Node node)
        {
            Nodes[++lastIndex] = node;
        }

        private (int NumberOFReounds, int NuberOfBlocks) CalculateNumbers(int Count)
        {
            (int NumberOFReounds, int NuberOfBlocks) result;

            Count = GetNextPowerOf2(Count);
            result.NuberOfBlocks = Count;
            result.NumberOFReounds = 1;
            while (Count > 1)
            {
                Count /= 2;
                result.NuberOfBlocks += Count;
                result.NumberOFReounds++;
            }
            return result;
        }

        private int GetNextPowerOf2(int number)
        {
            for (int i = 1; ; i++)
            {
                int powerOf2 = (int)Math.Pow(2, i);
                if (powerOf2 >= number)
                    return powerOf2;
            }
        }
    }
}
