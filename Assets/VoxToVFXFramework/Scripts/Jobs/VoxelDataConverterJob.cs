﻿using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using VoxToVFXFramework.Scripts.Converter;
using VoxToVFXFramework.Scripts.Data;

namespace VoxToVFXFramework.Scripts.Jobs
{
	[BurstCompile]
	public struct VoxelDataConverterJob : IJobParallelFor
	{
		[ReadOnly] public NativeArray<byte> Data;
		public UnsafeList<VoxelData>.ParallelWriter Result;
		public void Execute(int index)
		{
			int offset = index * 6 + 4;
			byte posX = Data[offset++];
			byte posY = Data[offset++];
			byte posZ = Data[offset++];
			byte colorIndex = Data[offset++];
			VoxelFace face = (VoxelFace)VoxelDataConverter.ToInt16(Data, offset);
			Result.AddNoResize(new VoxelData(posX, posY, posZ, colorIndex, face));
		}
	}
}
